using System;
using UnityEngine;

public class Loot : MonoBehaviour{
    [SerializeField] ItemSO itemSO;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator anim;
    [SerializeField] int quantity;

    public static event Action<ItemSO,int> OnItemLooted; 

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
            OnItemLooted?.Invoke(itemSO,quantity);
            Destroy(gameObject,.5f);
        }
    }
}
