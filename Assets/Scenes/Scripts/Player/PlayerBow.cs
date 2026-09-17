using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBow : MonoBehaviour
{
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Vector2 aimDirection = Vector2.right;
    [SerializeField] private float shootCoolDown = 0.5f;
    [SerializeField] private float shootTimer;
    [SerializeField] private Animator anim;
    [SerializeField] private Player player;

    private static readonly int isShootingHash = Animator.StringToHash("isShooting");
    private static readonly int aimXHash = Animator.StringToHash("aimX");
    private static readonly int aimYHash = Animator.StringToHash("aimY");

    

    void Start()
    {
        
    }


    private void OnEnable()
    {
        anim.SetLayerWeight(0,0);
        anim.SetLayerWeight(1,1);
    }
    private void OnDisable()
    {
        anim.SetLayerWeight(0,1);
        anim.SetLayerWeight(1,0);
    }
    
    void Update()
    {
         shootTimer -= Time.deltaTime;   
         HandheldAiming();
        
        if (Keyboard.current != null &&  Keyboard.current.cKey.wasPressedThisFrame && shootTimer <=0){
           player.IsShooting = true; 
           anim.SetBool(isShootingHash,true);
         }

    }

    private void Shoot(){

        if(shootTimer <=0){
            GameObject arrowObject = Instantiate(arrowPrefab,launchPoint.position,Quaternion.identity);
            Arrow arrow = arrowObject.GetComponent<Arrow>();
            arrow.SetDirection(aimDirection);
            shootTimer = shootCoolDown;
        }
        anim.SetBool(isShootingHash,false);
         player.IsShooting = false; 
    }

    private void HandheldAiming(){
        Vector2 input = Vector2.zero;
        if (Keyboard.current == null)
            return;
        if (Keyboard.current.aKey.isPressed) input.x = -1;
        if (Keyboard.current.dKey.isPressed) input.x = 1;
        if (Keyboard.current.wKey.isPressed) input.y = 1;
        if (Keyboard.current.sKey.isPressed) input.y = -1;
    
        if (input != Vector2.zero){
            aimDirection = input.normalized;
            launchPoint.localPosition = (Vector3)aimDirection * 1.0f;
        
            anim.SetFloat(aimXHash, aimDirection.x);
            anim.SetFloat(aimYHash, aimDirection.y);
        }else{
            if (aimDirection == Vector2.zero){
                aimDirection = Vector2.right;
                launchPoint.localPosition = new Vector3(1.0f, 0f, 0f);
                anim.SetFloat(aimXHash, 1.0f);
                anim.SetFloat(aimYHash, 0f);
            }
        }
    }
}
