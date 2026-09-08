using TMPro;
using UnityEngine;
using System;
[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    private Player player;
    [SerializeField] TMP_Text healthText;
      [SerializeField] Animator healthTextAnimator;
     private static readonly int lifeHash = Animator.StringToHash("lifetext");

    void Start()
    {
        player = GetComponent<Player>();
        healthText.text = "HP: "+ StatsManager.instance.Health +" / "+StatsManager.instance.MaxHealth;
    }
    
    public void ChangeHealth(int amount)
    {

        if(amount < 0)
        {
            StatsManager.instance.Health +=amount * (Math.Abs(amount)/( Math.Abs(amount)+StatsManager.instance.PlateArmour));
        }
        else
        {
            StatsManager.instance.Health +=amount;
        }
            
        healthText.text = "HP: "+ StatsManager.instance.Health +" / "+StatsManager.instance.MaxHealth;
        healthTextAnimator.Play(lifeHash);
        if(StatsManager.instance.Health <= 0)
        {
            player.gameObject.SetActive(false);
        }
    }
}
