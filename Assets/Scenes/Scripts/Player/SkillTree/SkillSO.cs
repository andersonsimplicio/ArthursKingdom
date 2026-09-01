using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New Skill",menuName = "SkillTree/Skill")]
public class SkillSO : ScriptableObject
{
    [SerializeField] private String skillName;
    [SerializeField] private int  maxLevel;
    [SerializeField] private Sprite  skillIcon;

    public Sprite _skillIcon
    {
        get { return this.skillIcon;} 
        set { this.skillIcon = value;} 
    }
}
