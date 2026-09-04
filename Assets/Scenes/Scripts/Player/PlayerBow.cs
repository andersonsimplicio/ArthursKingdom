using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBow : MonoBehaviour
{
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject arrowPrefab;
    
    // Corrigido para especificar o Vector2 do Unity para evitar erros de ambiguidade
    [SerializeField] private UnityEngine.Vector2 aimDirection = UnityEngine.Vector2.right;

    void Update()
    {
        HandlerAiming();
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //Refazer a parte shoot
    }

    private void HandlerAiming()
    {
        if (Keyboard.current == null) return;

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) horizontal = 1f;
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) horizontal = -1f;
        
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) vertical = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) vertical = -1f;

        // Guarda a nova direção apenas se alguma tecla de mira foi pressionada
        if (horizontal != 0 || vertical != 0)
        {
            aimDirection = new UnityEngine.Vector2(horizontal, vertical).normalized;
        }
    }
}