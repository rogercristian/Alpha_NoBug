using UnityEngine;
using UnityEngine.AI;

public class NavigationAgentControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] MovingPlayer[] target;
    [SerializeField] float repeatRate = 5f;
    [SerializeField] float time = .1f;
    [SerializeField] bool isEnemy = false;
    [SerializeField] bool followPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        if (followPlayer && isEnemy)
            InvokeRepeating("UpdateSearch",Random.Range(0,time),Random.Range(0,repeatRate));
        
    }
    private void Update()
    {
        if (followPlayer && !isEnemy)
        {

            NPCFollowPlayer();
        }
    }
    void UpdateSearch()
    {
        target = FindObjectsOfType<MovingPlayer>();

        if (target.Length == 0) return;

        int rand = Random.Range(0, target.Length);
        agent.destination = target[rand].transform.position;
        

        //Debug.Log(rand);
    }

    void NPCFollowPlayer()
    {
        target = FindObjectsOfType<MovingPlayer>();

        if (target.Length == 0) return;

        int rand = Random.Range(0, target.Length);
        agent.destination = target[rand].transform.position;
    }
}
