using UnityEngine;

public class Arrow : MonoBehaviour{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 direction = Vector2.right;
    [SerializeField] private float lifeSpan = 2f;
    [SerializeField] private float speed = 2f;

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
        Destroy(gameObject, lifeSpan);
    }

}
