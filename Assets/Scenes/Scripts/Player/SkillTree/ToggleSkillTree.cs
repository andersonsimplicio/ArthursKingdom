using UnityEngine;
using UnityEngine.InputSystem;
public class ToggleSkillTree : MonoBehaviour
{
    [SerializeField] CanvasGroup statsCanvas;
    private bool skillTreeOpen = false;

    
    
    
    void Update()
    {
       if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (skillTreeOpen)
            {
                Time.timeScale = 1;
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;
                skillTreeOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                skillTreeOpen = true;
            }
        }
    }

    // Update is called once per frame
}
