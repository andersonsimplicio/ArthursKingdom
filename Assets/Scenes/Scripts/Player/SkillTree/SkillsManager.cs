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
    }
}
