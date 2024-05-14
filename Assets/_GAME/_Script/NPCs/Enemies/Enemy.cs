using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    const string IDLE = "enemy_Idle";
    const string WALK = "enemy_Walk";


    private void Start()
    {
        GameEvents.Instance.AnimationChange(IDLE);
    }


    private void Update()
    {
        if (TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (!agent.isStopped)
                GameEvents.Instance.AnimationChange(WALK);
        }
    }


}
