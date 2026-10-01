using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopSlot : MonoBehaviour
{

    [SerializeField] private ItemSO itemSO;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int price;



     public void Initialize(ItemSO itemSO,int price){
            this.itemSO = itemSO;
            this.price = price;
            itemImage.sprite = itemSO.Icon;
            itemNameText.text = itemSO.ItemName;
            Debug.Log($"Nome: {itemNameText.text}");
            priceText.text = price < 10?$"0{price}":$"{price}"; 
    }


}
