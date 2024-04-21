using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform[] firePoint;
    float shootCountDown = 0;

   
    public void Shoot()
    {
        shootCountDown -= Time.deltaTime;

        if (shootCountDown <= 0)
        {
            // Instantiate(weaponData.projectile, firePoint.position, firePoint.rotation);
            SelectedWeaponShoot();
            shootCountDown = weaponData.fireRate;

        }
    }

    void SelectedWeaponShoot()
    {
        switch (weaponData.weponType)
        {
            case WeaponData.WeponType.SingleShoot:
                Instantiate(weaponData.projectile, firePoint[0].position, firePoint[0].rotation);
                break;
            case WeaponData.WeponType.TripleShoot:
                foreach (var item in firePoint)
                {
                    Instantiate(weaponData.projectile, item.position, item.rotation);
                }
                break;
            case WeaponData.WeponType.MultipleShoot:
                foreach (var item in firePoint)
                {
                    Instantiate(weaponData.projectile, item.position, item.rotation);
                }
                break;
            case WeaponData.WeponType.PursuitShoot:
                Instantiate(weaponData.projectile, firePoint[0].position, firePoint[0].rotation);
                break;
            default:
                break;
        }
    }
}
