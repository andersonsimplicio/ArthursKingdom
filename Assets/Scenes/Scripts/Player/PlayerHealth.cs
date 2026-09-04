using TMPro;
using UnityEngine;

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
            float damage = Mathf.Abs(amount);
            float armor = StatsManager.instance.PlateArmor;
            float damageMultiplier = 1f / (1f + armor * 0.05f);
            int finalDamage = Mathf.CeilToInt(damage * damageMultiplier);
            StatsManager.instance.Health = Mathf.Max(0, StatsManager.instance.Health - finalDamage);
            
        }else{
             StatsManager.instance.Health +=amount;
        }
       
        healthText.text = "HP: "+ StatsManager.instance.Health +" / "+StatsManager.instance.MaxHealth;
        healthTextAnimator.Play(lifeHash);
        if(StatsManager.instance.Health <= 0)
        {
            healthText.text = "HP: "+ 0 +" / "+StatsManager.instance.MaxHealth;
            player.gameObject.SetActive(false);
        }
    }
}
