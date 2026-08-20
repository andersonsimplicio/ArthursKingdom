using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

   [SerializeField] private Vector2 direction;
   
   [SerializeField] private float speed = 5f;
   [SerializeField] private bool isRunning =false;
    
   [SerializeField] private float speedRun = 8f;
   [SerializeField] private int health = 100;
   [SerializeField] private bool isKockBack;
  

    // Novo
    [SerializeField] private bool isAttacking = false;

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

     public int _health{
        get { return this.health;} 
        set { this.health = value;} 
    }

    private void OnInput(){
        direction = Vector2.zero;
    }

    void Start(){
        OnInput();
        inicialSpeed = 5f;
        rig = GetComponent<Rigidbody2D>();
        isKockBack = false;
        isAttacking = false;
    }

    void Update()
    {
       OnRun();
    }  

  #region Movimento

    private void FixedUpdate(){
       if(isKockBack == false) 
            OnMove();

        if (isAttacking)
        {
            rig.linearVelocity = Vector2.zero;
            return;
        }
        
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
     public void StartAttack(){
        isAttacking = true;

        // Para imediatamente
        rig.linearVelocity = Vector2.zero;
    }
    public bool IsAttacking()
    {
        return isAttacking;
    }
    public void EndAttack()
    {
        isAttacking = false;

        // Garante que não continue deslizando
        rig.linearVelocity = Vector2.zero;
    }

    public void knockBack(Transform enemy, float force,float stnuTime){
        isKockBack = true;
        Vector2 direcao = (transform.position - enemy.position).normalized;
        rig.linearVelocity = direcao * force;
        if (gameObject.activeInHierarchy){
            StartCoroutine(knockBackCounter(stnuTime));
        }
    }

    IEnumerator knockBackCounter(float stnuTime){
        yield return new WaitForSeconds(stnuTime);
         rig.linearVelocity = Vector2.zero;
         isKockBack = false;
    }
  #endregion
}