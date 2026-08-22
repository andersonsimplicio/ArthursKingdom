using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

   [SerializeField] private Vector2 direction;
   [SerializeField] private bool isRunning =false;    
   [SerializeField] private bool isKockBack;
    // Novo
    [SerializeField] private bool isAttacking = false;  
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
        rig = GetComponent<Rigidbody2D>();
        rig.interpolation = RigidbodyInterpolation2D.Interpolate;
        StatsManager.instance.BeginSpeedRun = StatsManager.instance.Speed;
        isKockBack = false;
        isAttacking = false;
    }

    void Update()
    {
       OnRun();
    }  

  #region Movimento

    private void FixedUpdate(){
        if (isAttacking || isKockBack)
        {
            rig.linearVelocity = Vector2.zero;
            return;
        }
        OnMove();
    }

    void OnMove()
    {
         rig.linearVelocity =Mover() * (StatsManager.instance.Speed);  
    }

    void OnRun()
    {
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed)
        {
           StatsManager.instance.Speed = StatsManager.instance.SpeedRun;
            _isRunning = true;
        }
        
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.wasReleasedThisFrame)
        {
           StatsManager.instance.Speed =StatsManager.instance.BeginSpeedRun;
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