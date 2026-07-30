using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealt : MonoBehaviour
{
    private Player player;
    [SerializeField] TMP_Text healthText;
    [SerializeField] int maxtHelt;
    [SerializeField] Animator healthTextAnimator;
     private static readonly int lifeHash = Animator.StringToHash("lifetext");

    void Start()
    {
        player = GetComponent<Player>();
        maxtHelt = player._health;
        healthText.text = "HP: "+ player._health +" / "+maxtHelt;
    }
    
    public void ChanngeHealth(int amount)
    {
        player._health +=amount;
        healthText.text = "HP: "+ player._health +" / "+maxtHelt;
        healthTextAnimator.Play(lifeHash);
        if(player._health <= 0)
        {
            player.gameObject.SetActive(false);
        }
    }
}
