using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform firePoint;
    float shootCountDown = 0;
    //InputManager inputManager;
    //void Start()
    //{
    //    inputManager = GetComponentInParent<InputManager>();    
    //}
   
    //void Update()
    //{
    //    float buttonRt = inputManager.GetButtonRtPressed();

    //    if (buttonRt > 0.1f || inputManager.GetInteractPressed())
    //    {
    //        shootCountDown -= Time.deltaTime;

    //        //if (shootCountDown <= 0)
    //        //{
    //        //    Instantiate(weaponData.projectile, firePoint.position, firePoint.rotation);

    //        //    shootCountDown = weaponData.fireRate;

    //        //}
    //    }

    //}
    public void Shoot()
    {
        shootCountDown -= Time.deltaTime;

        if (shootCountDown <= 0)
        {
            Instantiate(weaponData.projectile, firePoint.position, firePoint.rotation);

            shootCountDown = weaponData.fireRate;

        }
    }
}
