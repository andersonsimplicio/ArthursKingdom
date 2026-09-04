using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] private Rigidbody2D  rb;
    [SerializeField] private Vector2 direction = Vector2.right;
    [SerializeField] private float timeLyfe = 2;
    [SerializeField] private float speed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = direction*speed;
        RotateArrow();
        Destroy(gameObject, timeLyfe);
    }

    public Vector2 _direction
    {
        get{ return direction; }
        set{
             direction=value;
              AplicarMovimentoERotacao();
        }
    }
    private void AplicarMovimentoERotacao()
    {
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
        RotateArrow();
    }

    public void RotateArrow()
    {
       float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));    
    }
}
