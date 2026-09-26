using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvertorySlot : MonoBehaviour,IPointerClickHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private int quantidade = 0;
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private InventoryManager inventoryManager;

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ENTROU NO SLOT");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("SAIU DO SLOT");
    }
    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("Clique detectado: " + eventData.button);

        if (quantidade > 0)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("CLIQUE ESQUERDO");
                inventoryManager.useItem(this);
            }
        }
    }
    public ItemSO _ItemSO{
            set{ itemSO = value;}
            get{ return itemSO; }
    }
    public int Quantidade{
        get{return quantidade;}
        set{quantidade=value;}
    }


    public void UpdateUI(){
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
