using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvertorySlot : MonoBehaviour
{
  [SerializeField] private ItemSO itemSO;
  [SerializeField] private int quantidade;
  [SerializeField] private Image itemImage;
  [SerializeField] private TMP_Text quantityText;

public ItemSO _ItemSO{
        set{ itemSO = value;}
        get{ return itemSO; }
    }


public void UpdateUI(int quantidade){
        this.quantidade = quantidade;
        if (itemSO!= null)
        {
            itemImage.sprite = itemSO.Icon;
            itemImage.gameObject.SetActive(true);
            if(quantidade < 10)
            {
                quantityText.text = $"0{quantidade}";
            }
            else{
                quantityText.text = $"{quantidade}";
            }

        }
        else
        {
            itemImage.gameObject.SetActive(false);
            quantityText.text = $"";
        }
}



}
