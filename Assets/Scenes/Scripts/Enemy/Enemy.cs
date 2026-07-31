using UnityEngine;

public class Enemy : MonoBehaviour
{
     [SerializeField] private int damage = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Debug.Log($"Colidiu com: {collision.gameObject.name}");
       if(collision.gameObject.CompareTag("Player"))
       collision.gameObject.GetComponent<PlayerHealt>().ChanngeHealth(damage); 
    }
}
