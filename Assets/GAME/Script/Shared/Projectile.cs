using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] WeaponData weaponData;
    void Start()
    {
       body = GetComponent<Rigidbody>();       
       body.AddForce(transform.forward * weaponData.projectileSpeed , ForceMode.Impulse);
       Destroy(gameObject, weaponData.lifeProjectileDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Damage>(out var damage))
        {
            damage.hpManager.TakeDamage(weaponData.damage);
        }
            Destroy(gameObject);
    }

}
