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
        body.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);
        Destroy(gameObject, weaponData.lifeProjectileDuration);
        //if (weaponData.isPursuit)
        //    GetPorsuit();
    }
    private void FixedUpdate()
    {
        if (weaponData.isPursuit)
        {
            GetPorsuit();
        }
    }

    void GetPorsuit()
    {
        StartCoroutine(DelayPorsuit());
        target = FindAnyObjectByType<Enemy>().transform;
        Quaternion targetRotation;
        Debug.Log(target.name);
        if (target != null)
        {
            targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            body.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, weaponData.rotationVelocity));
            body.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);

        }

        if (target == null) Destroy(gameObject);
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
        yield return new WaitForSeconds(3);
    }
}
