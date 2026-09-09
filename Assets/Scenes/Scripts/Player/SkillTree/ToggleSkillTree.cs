using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleSkillTree : MonoBehaviour
{
    public CanvasGroup statsCanvas;
    private bool skillTreeOpen = false;
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {

            if ( skillTreeOpen ) {
            Time.timeScale = 1;
            statsCanvas.alpha = 1;
            statsCanvas.blocksRaycasts = true;
            skillTreeOpen = false;
            }else {
            Time.timeScale = 1;
            statsCanvas.alpha = 0;
            statsCanvas.blocksRaycasts = false;
            skillTreeOpen = true;
            }
        }
    }
}
