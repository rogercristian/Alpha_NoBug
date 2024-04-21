using UnityEngine;
using UnityEngine.InputSystem;
public class UIManager : MonoBehaviour
{
    public GameObject[] playerUiPanels;
    public GameObject[] joinMesseges;

    private void Start()
    {
        ManualPlayerJoin.instance.PlayerJoinedGame += PlayerJoinedGame;
        ManualPlayerJoin.instance.PlayerLeftGame += PlayerLeftGame;
    }
    private void OnDestroy()
    {
        ManualPlayerJoin.instance.PlayerJoinedGame -= PlayerJoinedGame;
        ManualPlayerJoin.instance.PlayerLeftGame -= PlayerLeftGame;
    }

    void PlayerJoinedGame(PlayerInput playerInput)
    {
        Show(playerInput);
    }

    void PlayerLeftGame(PlayerInput playerInput)
    {
        Hide(playerInput);
    }

    void Hide(PlayerInput playerInput)
    {
        playerUiPanels[playerInput.playerIndex].gameObject.SetActive(false);
        joinMesseges[playerInput.playerIndex].gameObject.SetActive(true);
    }
    void Show(PlayerInput playerInput)
    {
        playerUiPanels[playerInput.playerIndex].gameObject.SetActive(true);
        playerUiPanels[playerInput.playerIndex].GetComponent<PlayerUIPanel>().AssignPlayer(playerInput.playerIndex);
        joinMesseges[playerInput.playerIndex].gameObject.SetActive(false);
    }
}
