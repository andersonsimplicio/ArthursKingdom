using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int facingDirection = 1;
    [SerializeField] private float attackRange = 1.2f;
    [SerializeField] private EnemyState enemyState;
    
   

    private Rigidbody2D rb;
    [SerializeField] private Transform player;
    private Animator anim;

    private static readonly int isMovingHash = Animator.StringToHash("isMoving");
    private static readonly int isAttackHash = Animator.StringToHash("isAttack");
    private static readonly int isIdleHash = Animator.StringToHash("isIdle");


    void Start()
    {
        speed = 2f;
        enemyState = EnemyState.isDefault;
        rb = GetComponent<Rigidbody2D>();
        anim  =GetComponent<Animator>();
        ChangeState(EnemyState.isIdle);
    }

   void ChangeState(EnemyState newState)
    {   
        anim.SetBool(isAttackHash,newState==EnemyState.isAttack);
        if(enemyState == newState) return ;

        anim.SetBool(isIdleHash,newState==EnemyState.isIdle);
        anim.SetBool(isMovingHash,newState==EnemyState.isMoving);
        
        enemyState = newState;

    }


    void FixedUpdate()
    {
        if (enemyState == EnemyState.isMoving)
        {
            Chase();
        }else
            if(enemyState == EnemyState.isAttack)
            {
                //Fazer o attack
                rb.linearVelocity = Vector2.zero;
                ChangeState(EnemyState.isAttack);
            }
    }


    void Chase() {

        if(Vector2.Distance(transform.position,player.position) <= attackRange){
            ChangeState(EnemyState.isAttack);
        }else
        if(player.position.x > transform.position.x && facingDirection == -1 || 
               player.position.x < transform.position.x && facingDirection == 1){
                Flip();

            }
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;

    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(facingDirection,transform.localScale.y,transform.localScale.z);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
         
            if (player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.isMoving);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero;
        }
        ChangeState(EnemyState.isIdle);
    }
}

public enum EnemyState
{
    isIdle,
    isMoving,
    isAttack,
    isDefault
}