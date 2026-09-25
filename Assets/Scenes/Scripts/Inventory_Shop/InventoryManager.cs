using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private  int gold;
    [SerializeField] private  TMP_Text goldText;
    [SerializeField] private InvertorySlot[] itemSlots;

    public void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }

    public void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }

    public void AddItem(ItemSO item,int quantidade)
    {
        if(item!=null){
            if (item.IsGold)
            {
                gold+=quantidade;
                if(gold<10)
                    goldText.text = $"0{gold.ToString()}";
                else
                    goldText.text = $"{gold.ToString()}";
                return;
            }else{          
                if(item.IsGold==false)
                    foreach(var slot in itemSlots)
                    {
                        
                        if (slot._ItemSO == null)
                        {
                            slot._ItemSO = item;  
                            slot.UpdateUI(quantidade);
                            return;
                        }
                        else{
                            
                            if (slot._ItemSO.ItemName.Equals(item.ItemName))
                            {
                                Debug.Log($"ItemSO Name: {slot._ItemSO.ItemName}");
                            }
                        }    
                        
                    }
            }
        }
    }
}
