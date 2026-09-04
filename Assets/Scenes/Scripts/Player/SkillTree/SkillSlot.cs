using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;


public class SkillSlot : MonoBehaviour{
   [SerializeField] List<SkillSlot> prerequisitesSkillSlots;
   [SerializeField] SkillSO skillSO;
   [SerializeField] int leveAtual;
   [SerializeField] int valorLevelPoints;
   [SerializeField] bool isUnlocked;
   [SerializeField] Button skillButton;
   [SerializeField] Image skillIcon;
   [SerializeField] TMP_Text skillLevelText;

    public static event Action<SkillSlot> OnAbilityPointsSpent; 
    public static event Action<SkillSlot> OnSkillMaxed; 

    public int ValorLevelPoints
    {
        get{return valorLevelPoints; }
    }
    public SkillSO _skillSO
    {
        get{return skillSO; }
    }
    
    public bool _isUnlocked
    {
        get { return this.isUnlocked;}
        set { this.isUnlocked = value;}
    }
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
            OnAbilityPointsSpent?.Invoke(this);
            if(leveAtual >= skillSO._maxLevel)
            {
             OnSkillMaxed?.Invoke(this);   
            }
            UpdateUI();
        }
    }

    public void Unlock()
    {
        isUnlocked = true;
        UpdateUI();
    }

    public bool CanUnlockeSkill()
    {
        foreach (SkillSlot slot in prerequisitesSkillSlots)
        {
            if (!slot._isUnlocked || slot.leveAtual < slot.skillSO._maxLevel)
            {
                return false;
            }
        }

        return true;
    }

}
