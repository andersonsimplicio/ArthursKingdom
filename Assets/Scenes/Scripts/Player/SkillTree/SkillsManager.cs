using System;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnAbilityPointsSpent += HandleAbilityPointsSpent;
    }
     private void OnDisable()
    {
        SkillSlot.OnAbilityPointsSpent -= HandleAbilityPointsSpent;
    }

    private void HandleAbilityPointsSpent(SkillSlot slot)
    {
        String skillName = slot._skillSO._skillName;

        switch (skillName)
        {
            case "MaxHealthBoot":
                int health_value = 4 + slot.ValorLevelPoints;
                StatsManager.instance.UpdateMaxHealth(health_value);

            break;
            case "PlateArmor":
                int Armor_value = 2 + slot.ValorLevelPoints;
                StatsManager.instance.UpdateMaxArmor(Armor_value);

            break;
            default:
                Debug.LogWarning($"Nome de Skill não econtrado: {skillName}");
            break;
        }
    }
}
