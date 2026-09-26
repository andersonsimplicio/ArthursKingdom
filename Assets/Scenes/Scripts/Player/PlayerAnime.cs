using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnime : MonoBehaviour
{
   private Player player;
   [SerializeField] private SpriteRenderer spriteRenderer;
   private Animator animator;
   private static readonly int TransicaoHash = Animator.StringToHash("Transicao");
  [SerializeField] PlayerCombat playerCombat;

   public void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
         OnMove();
        OnRun();
        HandleAttack();          
    }
    void OnMove()
    {
        if (player._direction.sqrMagnitude > 0){             
            animator.SetInteger(TransicaoHash, 1);
        }else{
            animator.SetInteger(TransicaoHash, 0);
        }

        if (player._direction.x > 0){
            spriteRenderer.flipX = false;
        }else if (player._direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    void OnRun()
    {
        if (player._isRunning && player._direction.sqrMagnitude > 0)
        {   
            animator.SetInteger(TransicaoHash, 2);
        }
    }
    private void HandleAttack()
    {
        if (Mouse.current == null)
            return;

        if (!Mouse.current.leftButton.wasPressedThisFrame)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        playerCombat.attack();
    }

    
}