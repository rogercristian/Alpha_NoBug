using UnityEngine;

public class Missel : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] WeaponData weaponData;
    void Start()
    {
        float rand = Random.Range(1f, 2f);
        body = GetComponent<Rigidbody>();

        body.AddForce(transform.forward * weaponData.projectileSpeed * rand, ForceMode.Impulse);
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
