using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualPlayerJoin : MonoBehaviour
{
    public static ManualPlayerJoin instance { get; private set; }
    public List<PlayerInput> playerList = new List<PlayerInput>();

    [SerializeField] InputAction joinAction;
    [SerializeField] InputAction leaveAction;


    //EVENTS
    public event Action<PlayerInput> PlayerJoinedGame;
    public event Action<PlayerInput> PlayerLeftGame;

    private void Awake()
    {

        instance = this;

        joinAction.Enable();
        joinAction.performed += context => JoinAction(context);

        leaveAction.Enable();
        leaveAction.performed += context => LeaveAction(context);
    }
    private void OnDestroy()
    {
        joinAction.Disable();
        joinAction.performed -= context => JoinAction(context);
        leaveAction.Disable();
        leaveAction.performed -= context => LeaveAction(context);

    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerList.Add(playerInput);

        if (PlayerJoinedGame != null)
        {
            PlayerJoinedGame(playerInput);
        }
    }
    private void JoinAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);
    }

    private void LeaveAction(InputAction.CallbackContext context)
    {
        if (playerList.Count > 1)
        {
            foreach (var player in playerList)
            {
                foreach (var device in player.devices)
                {
                    if (device != null && context.control.device == device)
                    {
                        UnregisterPlayer(player);
                        return;
                    }
                }
            }
        }
    }
    private void UnregisterPlayer(PlayerInput playerInput)
    {
        playerList.Remove(playerInput);

        if (PlayerLeftGame != null)
        {
            PlayerLeftGame(playerInput);
        }

        Destroy(playerInput.transform.gameObject);
    }
}
