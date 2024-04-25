using UnityEngine;
using UnityEngine.AI;

public class EnemyUseWeapon : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    NavMeshAgent agent;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
        agent = GetComponentInParent<NavMeshAgent>();

        GameEvents.Instance.OnSeekPlayer += HandlerOnSeekPlayer;
    }

    private void HandlerOnSeekPlayer()
    {
        player = FindAnyObjectByType<MovingPlayer>().transform;
    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnSeekPlayer -= HandlerOnSeekPlayer;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent != null)
        {

            if (player == null) return;
            float dist = Vector3.Distance(transform.position, player.transform.position);

            if (dist <= agent.stoppingDistance)
            {
                weapon.Shoot();
            }
        }
    }

}
