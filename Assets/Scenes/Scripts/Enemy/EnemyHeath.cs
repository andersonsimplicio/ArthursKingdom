using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int expReward = 3;
    [SerializeField] private int maxHealth;
   
    public delegate void MonsterDefeated(int exp);
     public static event MonsterDefeated OnMonterDefeated;



    public void Start()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        health +=amount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }else
            if (health <=0){
                OnMonterDefeated(expReward);
                Destroy(gameObject);
            }
    }

}
