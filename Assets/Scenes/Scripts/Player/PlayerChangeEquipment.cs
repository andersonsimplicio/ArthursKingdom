using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerChangeEquipment : MonoBehaviour{
   

    [SerializeField] private PlayerCombat combat;
    [SerializeField] private PlayerBow archer;



    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame){
            combat.enabled = !combat.enabled;
            archer.enabled = !archer.enabled;

        }
    }
}
