using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    private Vector2 Move()
    {
        return new Vector2(0,0);
    }
}
