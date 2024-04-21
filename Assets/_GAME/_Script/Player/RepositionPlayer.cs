using UnityEngine;
using UnityEngine.InputSystem;

public class RepositionPlayer : MonoBehaviour
{
    [SerializeField] private int id;
    private void Start()
    {
        PlayerInput input = GetComponent<PlayerInput>();
        id = input.playerIndex;

        GameEvents.Instance.Reposition(id);
        GameEvents.Instance.SeekPlayer();
    }

}
