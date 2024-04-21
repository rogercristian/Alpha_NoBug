using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] WeaponData weaponData;

    Transform target;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (weaponData.isPursuit) return;
        body.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);
        Destroy(gameObject, weaponData.lifeProjectileDuration);
    }
    private void FixedUpdate()
    {
        if (weaponData.isPursuit)
        {
            StartCoroutine(DelayPorsuit());
            body.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);
            GetPorsuit();
        }
    }

    void GetPorsuit()
    {
        //  StartCoroutine(DelayPorsuit());
        target = FindAnyObjectByType<Enemy>()?.transform;
        Quaternion targetRotation;
        Destroy(gameObject, weaponData.lifeProjectileDuration);
        if (target != null)
        {
            targetRotation = Quaternion.LookRotation(target.position - transform.position);

            body.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, weaponData.maxDegreesDelta));
            body.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);
            Debug.Log(target.name);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Damage>(out var damage))
        {
            damage.hpManager.TakeDamage(weaponData.damage);
        }
        Destroy(gameObject);
    }
    IEnumerator DelayPorsuit()
    {
        yield return new WaitForEndOfFrame();
    }
}
