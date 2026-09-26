using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleSkillTree : MonoBehaviour
{
    public CanvasGroup statsCanvas;
    private bool skillTreeOpen = false;
    // Update is called once per frame
    void Update()
    {
       if (Keyboard.current != null &&
        Keyboard.current.rKey.wasPressedThisFrame){
        if (skillTreeOpen)
            CloseSkillTree();
        else
            OpenSkillTree();
        }
    }
    private void CloseSkillTree()
    {
        skillTreeOpen = false;

        statsCanvas.alpha = 0f;
        statsCanvas.interactable = false;
        statsCanvas.blocksRaycasts = false;
    }
    private void OpenSkillTree()
    {
        skillTreeOpen = true;

        statsCanvas.alpha = 1f;
        statsCanvas.interactable = true;
        statsCanvas.blocksRaycasts = true;
    }
}
