using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField] SkillSlot[] skillSlots;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] int availablePoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(SkillSlot slot in skillSlots)
        {
            slot._skillButton.onClick.AddListener(()=> CheckAvaliablePoints(slot)) ;
        }
        UpdateAbilityPoints(0);
    }

    public void CheckAvaliablePoints(SkillSlot slot)
    {
        if(availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }
    }    
    public void UpdateAbilityPoints(int amount)
    {
        availablePoints+=amount;
        pointsText.text = "Pontos de Habilidade: "+availablePoints;
        
    }

    private void OnEnable()
    {
        SkillSlot.OnAbilityPointsSpent += HandleAbilityPointsSpent;
        SkillSlot.OnSkillMaxed+= HandleSkillMaxed;
        ExpManager.OnLevelUp +=UpdateAbilityPoints;
    }
     private void OnDisable()
    {
        SkillSlot.OnAbilityPointsSpent -= HandleAbilityPointsSpent;
         SkillSlot.OnSkillMaxed-= HandleSkillMaxed;
         ExpManager.OnLevelUp -=UpdateAbilityPoints;
    }
    private void HandleAbilityPointsSpent(SkillSlot skillslot)
    {
        if(availablePoints > 0)
        {
            UpdateAbilityPoints(-1); 
        }
    }
  
    private void HandleSkillMaxed(SkillSlot skillslot)
    {
        foreach(SkillSlot slot in skillSlots)
        {
            if(!slot._isUnlocked && slot.CanUnlockeSkill()){
            slot.Unlock();
            }
        }
    }
}
