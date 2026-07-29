using TMPro;
using UnityEngine;


[RequireComponent(typeof(Player))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerHealt : MonoBehaviour
{
    private Player player;
    [SerializeField] TMP_Text healttex;
    [SerializeField] int maxtHelt;
    void Start()
    {
        player = GetComponent<Player>();
        maxtHelt = player._healt;
        healttex.text = "HP: "+ player._healt +" / "+maxtHelt;
    }
    
    public void ChanngeHealth(int amount)
    {
        player._healt +=amount;
        healttex.text = "HP: "+ player._healt +" / "+maxtHelt;
        if(player._healt <= 0)
        {
            player.gameObject.SetActive(false);
        }
    }
}
