using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damage = -10;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float weapomRange;
    [SerializeField] private LayerMask playerLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {   
            playerHealth.ChangeHealth(damage);
        }
    }

    public void Attack()
    {
        Debug.Log("Attack player");
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weapomRange,playerLayer); 
    }
}
   