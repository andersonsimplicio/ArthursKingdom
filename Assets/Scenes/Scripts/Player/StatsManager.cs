using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    public static StatsManager instance;
     [SerializeField] private TMP_Text healthText;

    [Header("Estatistica de Combate")]
    [SerializeField] private float weaponRange = 1f;
    
    [SerializeField] private float knowBackForce = 3;
    [SerializeField] private float knowBackTimer = 0.15f;
    [SerializeField] private float stuntimer = 0.3f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float timer = 1f;
    [SerializeField] private float coolDown = 1f;

    [Header("Estatistica de Movimento")]

    [SerializeField] private float speed = 5f; 
    [SerializeField] private float speedRun = 8f;
     [SerializeField] private float beginSpeedRun = 8f;

    [Header("Estatistica de Saúde ")]
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    

       private void Awake()
        {
            if (instance == null)
            {
                instance  = this;
            }else
            {
                Destroy(gameObject);
            }
    }

    public float WeaponRange
    {
        get => weaponRange;
        set => weaponRange = value;
    }

    public float KnowBackForce
    {
        get => knowBackForce;
        set => knowBackForce = value;
    }

    public float KnowBackTimer
    {
        get => knowBackTimer;
        set => knowBackTimer = value;
    }

    public float StunTimer
    {
        get => stuntimer;
        set => stuntimer = value;
    }

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public int Health
    {
        get => health;
        set => health = value;
    }
    public float SpeedRun
    {
        get => speedRun;
        set => speedRun = value;
    }
     public float Speed
    {
        get => speed;
        set => speed = value;
    }
    public float BeginSpeedRun
    {
        get => beginSpeedRun;
        set => beginSpeedRun = value;
    }

    public float Timer
    {
        get => timer;
        set => timer = value;
    }
    public float CoolDown
    {
        get => coolDown;
        set => coolDown = value;
    }


    public void UpdateMaxHealth(int amount)
    {
        maxHealth+=amount;
        healthText.text =  "HP: "+ health +" / "+maxHealth;
    }

}
