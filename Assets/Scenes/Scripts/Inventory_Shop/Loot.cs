using UnityEngine;

public class Loot : MonoBehaviour{
    [SerializeField] ItenSo itemSO;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator anim;
    [SerializeField] int quantity;

     private static readonly int lootPickaogHash = Animator.StringToHash("LootPickup");

    private void OnValidate(){
        if(itemSO==null ){
            return;
        }
        Debug.LogWarning("Tá aqui!");
        sr.sprite = itemSO.Icon;
        this.name = itemSO.ItemName;

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            anim.Play(lootPickaogHash);
            Destroy(gameObject,.5f);
        }
    }
}
