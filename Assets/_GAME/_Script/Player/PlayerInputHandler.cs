using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;
    [NonSerialized] MovingPlayer movingPlayer;

    private void Awake()
    {
        if (playerPrefabs != null)
            movingPlayer = Instantiate(playerPrefabs[GetComponent<PlayerInput>().playerIndex],
                transform.position, transform.rotation, transform).GetComponent<MovingPlayer>();
        if (TryGetComponent<CarControl>(out CarControl carControl))
            carControl = Instantiate(playerPrefabs[GetComponent<PlayerInput>().playerIndex],
                transform.position, transform.rotation).GetComponent<CarControl>();
    }
    public MovingPlayer GetMovingPlayer()
    {
        return movingPlayer;
    }
}
