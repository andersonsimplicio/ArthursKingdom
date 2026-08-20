using System.Collections;
using UnityEngine;

public class EnemyKnowBack : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;

    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void knowBack(Transform playerTransform, float knowBackForce,float stunTime){
        enemyMovement.ChangeState(EnemyState.isKnowBack);
        StartCoroutine(StunTimer(stunTime));
        Vector2 direction  = (transform.position - playerTransform.position ).normalized;
        rb.linearVelocity = direction * knowBackForce;
        
        Debug.Log("Aplicou recuo!");
    }
    IEnumerator StunTimer(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        enemyMovement.ChangeState(EnemyState.isIdle);

    }
   
}
