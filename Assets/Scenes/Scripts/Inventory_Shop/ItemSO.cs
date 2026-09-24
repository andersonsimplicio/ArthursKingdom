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
    [SerializeField]  int currentHealth;
    [SerializeField]  int maxHealth;
    [SerializeField]  int speed;
    [SerializeField]  int damage;

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

    public bool IsGold{
        set{ isGold = value; }
        get{ return isGold; }
    }

}
