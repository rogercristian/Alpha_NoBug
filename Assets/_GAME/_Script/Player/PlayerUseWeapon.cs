using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour
{
    private Weapon weapon;
    private InputManager inputManager;
    private void Start()
    {
        weapon = GetComponent<Weapon>();
        if (inputManager != null) return;
        inputManager = GetComponentInParent<InputManager>();
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
