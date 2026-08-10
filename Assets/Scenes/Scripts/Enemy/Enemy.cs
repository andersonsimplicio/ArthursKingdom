using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damage = -10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {   
            playerHealth.ChangeHealth(damage);
        }
    }
    public void Attack()
    {
        Debug.Log("Attack Player Now!");
    }
}
   