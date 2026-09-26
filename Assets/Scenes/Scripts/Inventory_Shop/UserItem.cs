using System.Collections;
using UnityEngine;

public class UserItem : MonoBehaviour
{
   
   public void ApllyItemEffect(ItemSO item){
        
        Debug.Log($"{item.ItemName}");
        if(item.CurrentHealth >0 )
            StatsManager.instance.UpdateHealth(item.CurrentHealth);
        
        if(item.Armour > 0)
            StatsManager.instance.UpdateArmour(item.Armour);

        if(item.Durantion > 0)
        {
            StartCoroutine(EffectTime(item,item.Durantion));
        }
        
    }
    private IEnumerator EffectTime(ItemSO item, float time)
    {
        yield return new WaitForSeconds(time);
        if(item.CurrentHealth >0 )
            StatsManager.instance.UpdateHealth(-item.CurrentHealth);
        
        if(item.Armour > 0)
            StatsManager.instance.UpdateArmour(-item.Armour);
    }
}
