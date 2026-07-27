using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnime : MonoBehaviour
{
   private Player player;
   private Animator animator;
   private static readonly int TransicaoHash = Animator.StringToHash("Transicao");
   public void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (player._direction.sqrMagnitude > 0){             
            animator.SetInteger(TransicaoHash, 1);
        }else{
            animator.SetInteger(TransicaoHash, 0);
        }
        
        if (player._direction.x > 0){             
          transform.eulerAngles = new Vector2(0,0);
        }else if (player._direction.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
