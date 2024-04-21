using UnityEngine;
using UnityEngine.AI;

public class NavigationAgentControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] MovingPlayer[] target;
    [SerializeField] float repeatRate = 5f;
    [SerializeField] float time = .1f;
    Weapon weapon;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        weapon = GetComponentInChildren<Weapon>();
        agent.autoBraking = false;
        InvokeRepeating("Reapete", time, repeatRate);
    }
    void Reapete()
    {
        target = FindObjectsOfType<MovingPlayer>();

        if (target.Length == 0) return;

        int rand = Random.Range(0, target.Length);
        agent.destination = target[rand].transform.position;
     
        //Debug.Log(rand);
    }
}
