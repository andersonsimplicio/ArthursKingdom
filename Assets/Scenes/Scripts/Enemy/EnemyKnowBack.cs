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

    public void knowBack(Transform playerTransform, float knowBackForce){
        enemyMovement.ChangeState(EnemyState.isKnowBack);
        Vector2 direction  = (transform.position - playerTransform.position ).normalized;
        rb.linearVelocity = direction * knowBackForce;
        
        Debug.Log("Aplicou recuo!");
    }

   
}
