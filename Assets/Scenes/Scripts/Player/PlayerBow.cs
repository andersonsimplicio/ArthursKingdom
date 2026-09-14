using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBow : MonoBehaviour
{
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Vector2 aimDirection = Vector2.right;
    [SerializeField] private float shootCoolDown = 0.5f;
    [SerializeField] private float shootTimer;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         shootTimer -= Time.deltaTime;   
         HandheldAiming();
        
        if (Keyboard.current != null &&  Keyboard.current.cKey.wasPressedThisFrame && shootTimer <=0){
            Shoot();
            
         }

    }

    private void Shoot()
    {
            GameObject arrowObject = Instantiate(arrowPrefab,launchPoint.position,Quaternion.identity);
            Arrow arrow = arrowObject.GetComponent<Arrow>();
            arrow.SetDirection(aimDirection);
            shootTimer = shootCoolDown;
    }

    private void HandheldAiming()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current == null)
            return;

        if (Keyboard.current.aKey.isPressed)
            input.x = -1;

        if (Keyboard.current.dKey.isPressed)
            input.x = 1;

        if (Keyboard.current.wKey.isPressed)
            input.y = 1;

        if (Keyboard.current.sKey.isPressed)
            input.y = -1;

        if (input != Vector2.zero)
        {
            aimDirection = input.normalized;

            // Move o LaunchPoint na direção da mira
           launchPoint.localPosition =  (Vector3)aimDirection * 1.0f;
        }
    }



}
