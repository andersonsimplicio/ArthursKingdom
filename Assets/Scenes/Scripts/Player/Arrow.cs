using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 direction = Vector2.right;
    [SerializeField] private float lifeSpaw = 2;    
    [SerializeField] private float speed = 2;    
    void Start()
    {
        rb.linearVelocity = speed*direction;
        Destroy(gameObject,lifeSpaw);
    }

}
