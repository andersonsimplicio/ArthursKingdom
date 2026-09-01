using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
   [SerializeField] SkillSO skillSO;
   [SerializeField] Image skillIcon;

    private void Oalidate()
    {
        if (skillSO!=null)
        {
            skillIcon.sprite = skillSO._skillIcon;
        }
    }




}
