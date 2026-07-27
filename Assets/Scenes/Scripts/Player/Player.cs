using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

   [SerializeField] private Vector2 direction;
   
   [SerializeField] private float speed = 5f;
   [SerializeField] private bool isRunning =false;
    
   [SerializeField] private float speedRun = 8f;

    private float inicialSpeed;
    private Rigidbody2D rig; 


    public Vector2 _direction{
        get { return this.direction;} 
        set { this.direction = value;} 
    }

    public bool _isRunning{
        get { return this.isRunning;} 
        set { this.isRunning = value;} 
    }

    private void OnInput(){
        direction = Vector2.zero;
    }

    void Start(){
        OnInput();
        inicialSpeed = 5f;
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
         OnRun();
    }  

  
  #region Movimento

    private void FixedUpdate(){
       OnMove();
        
    }
    void OnMove()
    {
         rig.linearVelocity =Mover() * (speed);  
    }

    void OnRun()
    {
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed)
        {
            speed = speedRun;
            _isRunning = true;
        }
        
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.wasReleasedThisFrame)
        {
            speed = inicialSpeed;
             _isRunning = false;
        }
    }


    Vector2 Mover(){
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
  #endregion
}
