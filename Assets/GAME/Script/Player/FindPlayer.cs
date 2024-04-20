using Cinemachine;
using UnityEngine;
public class FindPlayer : MonoBehaviour
{
    CinemachineTargetGroup targetGroup;

    Transform target;
    private void OnEnable()
    {
        GameEvents.Instance.OnSeekPlayer += Handler_OnSeekPlayer;
       
            targetGroup = GetComponent<CinemachineTargetGroup>();

    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnSeekPlayer -= Handler_OnSeekPlayer;
    }
    private void Handler_OnSeekPlayer()
    {
        MovingPlayer input = FindObjectOfType<MovingPlayer>();

        target = input.transform;
        targetGroup.AddMember(target, 1, 1);

    }
}
