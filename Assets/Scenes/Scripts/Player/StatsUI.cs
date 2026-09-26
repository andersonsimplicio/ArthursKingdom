using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class StatsUI : MonoBehaviour
{

    [SerializeField] private GameObject[] statsSlots;
    [SerializeField] private CanvasGroup statsCanvas;

    private bool statsOpen = false;

    private void Start()
    {
        CloseStats();
        updateAllStats();
    }

    private void Update()
    {
        updateAllStats();

        if (Keyboard.current != null &&
            Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (statsOpen)
            {
                CloseStats();
            }
            else
            {
                OpenStats();
            }
        }
    }

    private void OpenStats()
    {
        statsOpen = true;

        Time.timeScale = 0f;

        statsCanvas.alpha = 1f;
        statsCanvas.interactable = true;
        statsCanvas.blocksRaycasts = true;

        updateAllStats();
    }

    private void CloseStats()
    {
        statsOpen = false;

        Time.timeScale = 1f;

        statsCanvas.alpha = 0f;
        statsCanvas.interactable = false;
        statsCanvas.blocksRaycasts = false;
    }

    private void updateAllStats()
    {
        updateDamage();
        updateSpeed();
        updateArmour();
    }

    public void updateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text =
            $"Damage: {StatsManager.instance.Damage}";
    }

    private void updateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text =
            $"Speed: {StatsManager.instance.Speed}";
    }

    public void updateArmour()
    {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text =
            $"Armour: {StatsManager.instance.PlateArmour}";
    }
}

