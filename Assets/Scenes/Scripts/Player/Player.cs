using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private Vector2 direction;
    private float speed = 5f;
    private Rigidbody2D rig; 

    void Start()
    {
        this.direction = Vector2.zero;
        rig = GetComponent<Rigidbody2D>();
    }
    
   void Update()
    {
      
    }

    private void FixedUpdate()
    {
         rig.linearVelocity =Mover() * (speed);    
    }

    Vector2 Mover()
    {
         this.direction = Vector2.zero;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) 
            this.direction.y = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) 
            this.direction.y = -1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) 
            this.direction.x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) 
            this.direction.x = 1f;
        return this.direction.normalized;
    }
  
}
