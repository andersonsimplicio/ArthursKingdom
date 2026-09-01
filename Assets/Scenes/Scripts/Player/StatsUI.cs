using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class StatsUI : MonoBehaviour
{

   [SerializeField] GameObject[] statsSlots;
   [SerializeField] CanvasGroup statsCanvas;
   
   [SerializeField] bool statsOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateAllStats();
    }

    void updateAllStats()
    {
        updateDamage();
        updateSpeed();
    }
    public void updateDamage()
    {
         statsSlots[0].GetComponentInChildren<TMP_Text>().text = $"Damage: {StatsManager.instance.Damage}";
    }
    public void updateSpeed()
    {
         statsSlots[1].GetComponentInChildren<TMP_Text>().text = $"Speed: {StatsManager.instance.Speed}";
    }

    public void Update()
    {

         updateAllStats();
         if (Keyboard.current != null && Keyboard.current.fKey.wasPressedThisFrame) { 
                
                if(statsOpen){
                    Time.timeScale = 1;
                    statsCanvas.alpha = 0;
                    statsOpen = false;
                    updateAllStats();
                }else{
                    Time.timeScale = 0;
                    statsOpen = true;
                    statsCanvas.alpha = 1;
                    updateAllStats();
                }
        }
    }

}
