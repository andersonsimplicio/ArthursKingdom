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

    public void knowBack(Transform playerTransform, float knowBackForce,float  knowBackTimer, float stunTime){
        enemyMovement.ChangeState(EnemyState.isKnowBack);
        StartCoroutine(StunTimer(knowBackTimer,stunTime));
        Vector2 direction  = (transform.position - playerTransform.position ).normalized;
        rb.linearVelocity = direction * knowBackForce;
        
        Debug.Log("Aplicou recuo!");
    }
    IEnumerator StunTimer(float  knowBackTimer,float stunTime)
    {
        yield return new WaitForSeconds(knowBackTimer);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.ChangeState(EnemyState.isIdle);

    }
   
}
