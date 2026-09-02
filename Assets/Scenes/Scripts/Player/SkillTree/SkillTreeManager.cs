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
            slot._skillButton.onClick.AddListener(slot.TryUpgradeSkill);
        }
        UpdateAbilityPoints(0);
    }

    public void UpdateAbilityPoints(int amount)
    {
        availablePoints+=amount;
        pointsText.text = "Pontos de Habilidade: "+availablePoints;
    }

}
