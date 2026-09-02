using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
public class SkillSlot : MonoBehaviour
{
   [SerializeField] SkillSO skillSO;
   [SerializeField] int leveAtual;
   [SerializeField] bool isUnlocked;
   [SerializeField] Button skillButton;
   [SerializeField] Image skillIcon;
   [SerializeField] TMP_Text skillLevelText;


    public Button _skillButton
    {
        get { return this.skillButton;}
        set { this.skillButton = value;}
    }
    private void OnValidate()
    {
        if (skillSO !=null && skillLevelText != null)
        {
            skillIcon.sprite = skillSO._skillIcon;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        skillIcon.sprite = skillSO._skillIcon;
        if (isUnlocked)
        {
            skillButton.interactable = true;    
            skillLevelText.text = leveAtual.ToString()+"/"+skillSO._maxLevel.ToString() ;
            skillIcon.color = Color.white;
        }
        else
        {
             skillButton.interactable = false; 
            skillLevelText.text ="Locked";
            skillIcon.color = Color.grey;

        }
    }

    public void TryUpgradeSkill()
    {
        if(isUnlocked && leveAtual < skillSO._maxLevel)
        {
            leveAtual++;
            UpdateUI();
        }
    }




}
