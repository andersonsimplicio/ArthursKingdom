using UnityEngine;

public class PlayerCombat : MonoBehaviour{
[SerializeField] Animator animator;
[SerializeField] private float coolDown = 1f;
[SerializeField] private float timer = 1f;

[SerializeField] private float weaponRange = 1f;
[SerializeField] private int damage = 10;
[SerializeField] private Transform attackPoint;
[SerializeField] LayerMask enemyLayer;



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
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,weaponRange);
            if(enemies.Length > 0 && enemies[0].GetComponent<EnemyHeath>()!=null){
                 enemies[0].GetComponent<EnemyHeath>().ChangeHealth(-damage);
                 timer =coolDown;
             }
        }
    }
    public void finishAttacking()    {
        animator.SetBool(attackHash,false);
    }

    /* 
    private void OnDrawGizmos(){
       if (attackPoint == null) return;

        // Fica vermelho se detectar um Player, ou verde quando a área estiver livre
        Gizmos.color = attackPoint ? Color.aquamarine : Color.black;

        // Desenha o círculo exato do OverlapCircleAll
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
    */
}
