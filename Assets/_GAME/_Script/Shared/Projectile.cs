using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour, IPooledObject
{
    Rigidbody body;
    [SerializeField] WeaponData weaponData;

    Transform target;

  public void OnObjectSpawn()
    {
        body = GetComponent<Rigidbody>();
        if (weaponData.isPursuit) return;
        //  body.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);
        transform.position += transform.forward * weaponData.projectileSpeed * Time.deltaTime;
        StartCoroutine(Esperar());
    }
    private void Update()
    {
        OnObjectSpawn();
        if (weaponData.isPursuit)
        {
            StartCoroutine(DelayPorsuit());
            //body.AddForce(transform.forward * weaponData.projectileSpeed, ForceMode.Impulse);
            transform.position += transform.forward * weaponData.projectileSpeed * Time.deltaTime;
            GetPorsuit();
        }
    }

    void GetPorsuit()
    {
        //  StartCoroutine(DelayPorsuit());
        target = FindAnyObjectByType<Enemy>()?.transform;
        Quaternion targetRotation;
        StartCoroutine(Esperar());
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
        gameObject.SetActive(false);
    }
    IEnumerator DelayPorsuit()
    {
        yield return new WaitForEndOfFrame();
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(weaponData.lifeProjectileDuration);
        gameObject.SetActive(false);
    }
}
