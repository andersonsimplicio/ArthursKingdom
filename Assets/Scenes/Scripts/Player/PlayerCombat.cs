using UnityEngine;

public class PlayerCombat : MonoBehaviour{
[SerializeField] Animator animator;
[SerializeField] private float coolDown = 1f;
[SerializeField] private float timer = 1f;


[SerializeField] private float weaponRange = 1f;
[SerializeField] private int damage = 10;
[SerializeField] private Transform attackPoint;
[SerializeField] LayerMask enemyLayer;

//Criação de recuo
[SerializeField] private float knowBackForce = 50;


private static readonly int attackHash = Animator.StringToHash("isAttack");
private static readonly int TransicaoHash = Animator.StringToHash("Transicao");
    void FixedUpdate(){
        if(timer > 0)
        {
            timer-=Time.deltaTime;
        }
    }  

    public void attack()    {
        if(timer <=0){
            animator.SetInteger(TransicaoHash, 3);
            animator.SetBool(attackHash,true);
            timer =coolDown;
        }
    }
    public void DealDamage(){
           Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,weaponRange, enemyLayer);
           foreach (Collider2D enemy in enemies){
                if (enemy is not CapsuleCollider2D capsule)
                    continue;

                Rigidbody2D rb = capsule.attachedRigidbody;

                if (rb == null)
                    continue;

                EnemyHeath health = rb.GetComponent<EnemyHeath>();
                EnemyKnowBack recuo = rb.GetComponent<EnemyKnowBack>();
                if (health != null && recuo != null)
                {
                    health.ChangeHealth(-damage);
                    recuo.knowBack(transform,knowBackForce);
                }
           }
    }



    public void finishAttacking()    {
        animator.SetBool(attackHash,false);
    }


    private void OnDrawGizmos(){
       if (attackPoint == null) return;

        // Fica vermelho se detectar um Player, ou verde quando a área estiver livre
        Gizmos.color = attackPoint ? Color.aquamarine : Color.black;

        // Desenha o círculo exato do OverlapCircleAll
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
    
}
