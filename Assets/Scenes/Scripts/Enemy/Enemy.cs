using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damage = -10;
    [SerializeField] float weaponRange =1.2f;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform attackPoint;

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
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position,weaponRange,playerLayer);
        Debug.Log($"Hist: {hits.Length}");
        if(hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(damage);
        }
    }
}
   