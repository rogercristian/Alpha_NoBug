using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour
{
   private Weapon weapon;
   private InputManager inputManager;
    private void Start()
    {
        inputManager = GetComponentInParent<InputManager>();
        weapon = GetComponent<Weapon>();
    }
    void Update()
    {
        float buttonRt = inputManager.GetButtonRtPressed();

        if (buttonRt > 0.1f || inputManager.GetInteractPressed())
        {
            weapon.Shoot();
        }
    }
}
