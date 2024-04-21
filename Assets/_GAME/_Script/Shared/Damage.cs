using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] internal HpManager hpManager;

    private void Awake()
    {
        hpManager.OnDie += HpManager_OnDie;
    }
    private void OnDestroy()
    {
        hpManager.OnDie -= HpManager_OnDie;

    }
    private void HpManager_OnDie()
    {
        Destroy(gameObject);
    }
}
