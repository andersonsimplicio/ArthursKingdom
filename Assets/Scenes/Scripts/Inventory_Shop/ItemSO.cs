using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Invetory/item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private String itemName;
    [SerializeField] [TextArea]String description;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool isGold;

    [Header("Estatística")]
    [SerializeField]  private int currentHealth;
    [SerializeField]  private int maxHealth;
    [SerializeField]  private int speed;
    [SerializeField]  private int damage;
    [SerializeField]  private int armour;

    [Header("Duração")]
    [SerializeField]  float duracao;
   

    public Sprite Icon
    {
        get{return icon;}
    }

    public String ItemName
    {
        get{return itemName;}
    }   
    public int CurrentHealth
    {
        set{ currentHealth = value; }
        get{return currentHealth; }
    }
     public int Armour
    {
        set{ armour = value; }
        get{return armour; }
    }

    public bool IsGold{
        set{ isGold = value; }
        get{ return isGold; }
    }
     public float Durantion{
        set{ duracao = value; }
        get{ return duracao; }
    }
}
