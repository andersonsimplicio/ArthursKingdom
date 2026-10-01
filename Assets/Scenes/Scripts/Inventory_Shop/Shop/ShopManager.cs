using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
  [SerializeField] private List<ShopItems>  shopItems;
  [SerializeField] private ShopSlot[] shopSlots;


   public void Start()
    {
        PreencherLoja();
    } 
  public void PreencherLoja(){

       
        for(int i = 0;i < shopItems.Count && i < shopSlots.Length; i++)
        {
            ShopItems shopItem = shopItems[i];
            shopSlots[i].Initialize(shopItem._itemSO,shopItem._price);
            shopSlots[i].gameObject.SetActive(true);
        }   
        Debug.Log($"shopItems.Count {shopItems.Count}");
        Debug.Log($"shopSlots.Length: {shopSlots.Length}");  

        for(int i = shopItems.Count;i < shopSlots.Length; i++)
        {
            shopSlots[i].gameObject.SetActive(false);
        } 
   }  
}

[System.Serializable]
public class ShopItems{
       [SerializeField] private ItemSO itemSO;
       [SerializeField] private int price;

        public int  _price{
                get{return price;}
                set{ price = value; }
        }

        public ItemSO _itemSO{
            get{ return itemSO; }
            set{ itemSO = value;}    
        }

}
