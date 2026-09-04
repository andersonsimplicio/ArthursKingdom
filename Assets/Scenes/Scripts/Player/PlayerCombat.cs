using UnityEngine;

public class PlayerCombat : MonoBehaviour{
[SerializeField] Animator animator;
[SerializeField] private Transform attackPoint;
[SerializeField] LayerMask enemyLayer;
[SerializeField] StatsUI uiStats;

//Criação de recuo

private static readonly int attackHash = Animator.StringToHash("isAttack");
private static readonly int TransicaoHash = Animator.StringToHash("Transicao");

    void FixedUpdate(){
        if(StatsManager.instance.Timer > 0 )
        {
            StatsManager.instance.Timer-=Time.deltaTime;
        }
    }  

    public void attack()    {
        
        if(StatsManager.instance.Timer <=0){
            animator.SetInteger(TransicaoHash, 3);
            animator.SetBool(attackHash,true);
            StatsManager.instance.Timer= StatsManager.instance.CoolDown;
        }
    }
    public void DealDamage(){
           
           Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,StatsManager.instance.WeaponRange, enemyLayer);
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
                    //StatsManager.instance.Damage+=0;
                    health.ChangeHealth(-StatsManager.instance.Damage);
                    recuo.knowBack(transform,StatsManager.instance.KnowBackForce,StatsManager.instance.KnowBackTimer,StatsManager.instance.StunTimer);
                    
                    uiStats.updateDamage();
                }
           }
    }
    public void finishAttacking()    {
        animator.SetBool(attackHash,false);
    }
/*

    private void OnDrawGizmos(){
    if (attackPoint == null) return;
    if (StatsManager.instance == null) return;
        // Fica vermelho se detectar um Player, ou verde quando a área estiver livre
    Gizmos.color = attackPoint ? Color.aquamarine : Color.black;
    Gizmos.DrawWireSphere(attackPoint.position, StatsManager.instance.WeaponRange);
    
    }
    */
}
