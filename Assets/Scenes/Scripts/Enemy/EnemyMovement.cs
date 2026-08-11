using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int facingDirection = 1;
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCoolDown = 2f;
    [SerializeField] private float attackCoolDownTimer;
    [SerializeField] private float playerDetectRange = 5f;
    [SerializeField] Transform detectkPoint;
    [SerializeField] LayerMask playerLayer;
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
        attackRange = 1.2f;
        rb = GetComponent<Rigidbody2D>();
        anim  =GetComponent<Animator>();
        ChangeState(EnemyState.isIdle);
    }

   void ChangeState(EnemyState newState)
    {
    
        anim.SetBool(isAttackHash,newState==EnemyState.isAttack);
        enemyState = newState;
        anim.SetBool(isIdleHash,newState==EnemyState.isIdle);
        anim.SetBool(isMovingHash,newState==EnemyState.isMoving);

       
    }


    void FixedUpdate()
    {
        CheckForPlayer();
        if(attackCoolDownTimer > 0){
            attackCoolDownTimer-= Time.deltaTime;
        }

        if (enemyState == EnemyState.isMoving)
        {
            Chase();
        }else if(enemyState == EnemyState.isAttack)
        {
            // não faz nada
            rb.linearVelocity =  Vector2.zero;
            ChangeState(EnemyState.isAttack);
            
        }
    }
    void Chase()
    {
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

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectkPoint.position,attackRange,playerLayer);
        
        if(hits.Length > 0)
        {
            player = hits[0].transform;
            attackCoolDownTimer = attackCoolDown;
            if(Vector2.Distance(transform.position,player.transform.position) <= attackRange && attackCoolDownTimer <=0)
            {
            
                ChangeState(EnemyState.isAttack);
            }else
            if(Vector2.Distance(transform.position,player.transform.position) >= attackRange)
                ChangeState(EnemyState.isMoving);
        }
        else{
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.isIdle);
        }      
    }
}

public enum EnemyState
{
    isIdle,
    isMoving,
    isAttack,
    isDefault
}