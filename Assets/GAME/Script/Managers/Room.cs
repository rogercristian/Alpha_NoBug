using Cinemachine;
using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    public event Action<Room> OnRoomChange;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovingPlayer>(out var movingPlayer))
        {
            OnRoomChange?.Invoke(this);
            Debug.Log("colisor room" + movingPlayer.name);
        }
    }
    public void DisableCamera()
    {
        virtualCamera.enabled = false;
    }

    public void EnableCamera(Transform target)
    {
        virtualCamera.enabled = true;
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }
}
