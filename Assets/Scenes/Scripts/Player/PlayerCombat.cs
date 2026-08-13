using UnityEngine;

public class PlayerCombat : MonoBehaviour{
[SerializeField] Animator animator;
[SerializeField] private float coolDown = 15f;
[SerializeField] private float timer = 1f;
private static readonly int attackHash = Animator.StringToHash("isAttack");
 private static readonly int TransicaoHash = Animator.StringToHash("Transicao");


  void FixedUpdate()
    {
        if(timer > 0)
        {
            timer-=Time.deltaTime;
        }
    }  
  public void attack()    {
        if(timer <=0){
            animator.SetInteger(TransicaoHash, 3);
            animator.SetBool(attackHash,true);
            timer  =coolDown;
        }
    }
     public void finishAttacking()    {
        animator.SetBool(attackHash,false);
    }
}
