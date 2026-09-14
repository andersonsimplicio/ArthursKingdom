using UnityEngine;

public class Arrow : MonoBehaviour{
   
    
    [SerializeField] private int damage;
    [SerializeField] private float lifeSpawn= 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float knockBackForce;
    [SerializeField] private float knockBackTime;
    [SerializeField] private float stunTime;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 direction = Vector2.right;
    [SerializeField] private LayerMask enemyLayer;




    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;

        float angle = Mathf.Atan2(
            direction.y,
            direction.x
        ) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Start()
    {
        rb.linearVelocity = speed * direction;
        Destroy(gameObject, lifeSpawn);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning( $" Saude: {collision.gameObject.GetComponent<EnemyHeath>().Health}");

        if ( (enemyLayer.value & (1<< collision.gameObject.layer)) > 0){
            collision.gameObject.GetComponent<EnemyHeath>().ChangeHealth(-damage);
            collision.gameObject.GetComponent<EnemyKnowBack>().knowBack(transform,knockBackForce,knockBackTime,stunTime);
            Debug.LogWarning( $" Saude: {collision.gameObject.GetComponent<EnemyHeath>().Health}");
        }
        
    }
}