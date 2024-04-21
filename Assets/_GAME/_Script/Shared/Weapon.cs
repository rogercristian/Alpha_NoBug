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
        foreach (var item in firePoint)
        {
            switch (weaponData.weponType)
            {
                case WeaponData.WeponType.SingleShoot:
                    Instantiate(weaponData.projectile, item.position, item.rotation);
                    break;
                case WeaponData.WeponType.TripleShoot:

                    Instantiate(weaponData.projectile, item.position, item.rotation);

                    break;
                case WeaponData.WeponType.MultipleShoot:

                    Instantiate(weaponData.projectile, item.position, item.rotation);

                    break;
                case WeaponData.WeponType.PursuitShoot:
                    Instantiate(weaponData.projectile, item.position, item.rotation);
                    break;
                default:
                    break;
            }
        }
    }
}
