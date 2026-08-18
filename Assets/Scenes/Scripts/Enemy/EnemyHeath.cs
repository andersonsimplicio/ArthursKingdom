using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;


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
                Destroy(gameObject);
            }
    }
}
