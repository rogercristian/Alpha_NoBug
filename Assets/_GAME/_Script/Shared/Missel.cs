using System.Collections;
using UnityEngine;

public class Missel : MonoBehaviour, IPooledObject
{
    Rigidbody body;
    [SerializeField] WeaponData weaponData;
    public void OnObjectSpawn()
    {
        float rand = Random.Range(1f, 2f);
        body = GetComponent<Rigidbody>();
        //body.AddForce(transform.position += transform.forward * weaponData.projectileSpeed * rand, ForceMode.Impulse);
        transform.position += transform.forward * weaponData.projectileSpeed * rand * Time.deltaTime;
    }
    private void Update()
    {
        OnObjectSpawn();
        StartCoroutine(Esperar());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Damage>(out var damage))
        {
            damage.hpManager.TakeDamage(weaponData.damage);
        }
        gameObject.SetActive(false);
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(weaponData.lifeProjectileDuration);
        gameObject.SetActive(false);
    }
}
