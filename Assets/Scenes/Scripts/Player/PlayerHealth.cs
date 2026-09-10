using TMPro;
using UnityEngine;
using System;
[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    private Player player;
    [SerializeField] TMP_Text healthText;
      [SerializeField] Animator healthTextAnimator;
     private static readonly int lifeHash = Animator.StringToHash("lifetext");

    void Start()
    {
        player = GetComponent<Player>();
        healthText.text = "HP: "+ StatsManager.instance.Health +" / "+StatsManager.instance.MaxHealth;
    }
    
    public void ChangeHealth(int amount)
    {

        if(amount < 0)
        {
            int dano =  CalculoDanoAR(amount);;
           
            StatsManager.instance.Health +=(dano);
        }
        else{
            StatsManager.instance.Health +=amount;
        }
            
        healthText.text = "HP: "+ StatsManager.instance.Health +" / "+StatsManager.instance.MaxHealth;
        healthTextAnimator.Play(lifeHash);
        if(StatsManager.instance.Health <= 0)
        {
            StatsManager.instance.Health = 0;
            player.gameObject.SetActive(false);
        }
    }

    public int CalculoDano(int danoRecebido)
    {
        float procentagem = StatsManager.instance.PlateArmour/(float)StatsManager.instance.PlateArmourMax;
        float dano = danoRecebido * (1f - procentagem * 0.8f);       
        dano = (int) Math.Round(dano, MidpointRounding.AwayFromZero);
       
        return (int) dano;
    }
    public int CalculoDanoAR(int danoRecebido)
    {
        float procentagem = (float)StatsManager.instance.PlateArmour/((float)StatsManager.instance.PlateArmourMax+5);
        int dano = (int)Math.Round(danoRecebido - danoRecebido*procentagem, MidpointRounding.AwayFromZero);
        Debug.Log($" Procentagem {procentagem}%");
        Debug.Log($" Dano {dano}");
        return dano;
    }

}
