using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{

    [SerializeField] int level=0;
    [SerializeField] int currentExp;
    [SerializeField] int expToLevel = 10;
    [SerializeField] float expGrowthMultipler = 1.3f;
    [SerializeField] Slider expSlider;
    [SerializeField] TMP_Text currentTextLevel;



    public void GainExperience(int amount)
    {
        currentExp+=amount;
        if (currentExp > expToLevel){
            levelUp();
        }
    }

    private void levelUp()
    {
        level++;
        currentExp-=expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel*expGrowthMultipler);
        StatsManager.instance.Damage+=5;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    public void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            GainExperience(2);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentTextLevel.text = $"Level: {level} "; 
    }

    private void OnEnable()
    {
        EnemyHeath.OnMonterDefeated += GainExperience;
    }
     private void OnDisable()
    {
        EnemyHeath.OnMonterDefeated -= GainExperience;
    }


 
}
