using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] List<Room> rooms;
    [SerializeField] Transform cameraTransform;

    [field: SerializeField] private Room currentRoom;

    public Room CurrentRoom
    {
        get { return currentRoom; }
        set
        {
            currentRoom?.DisableCamera();
            currentRoom = value;
            currentRoom.EnableCamera(cameraTransform);
        }
    }
    private void Awake() => instance = this;

    private void Start()
    {
        rooms.ForEach(room => room.OnRoomChange += HandlerRoomChange);
    }
    private void OnDestroy()
    {
        rooms.ForEach(room => room.OnRoomChange -= HandlerRoomChange);

    }
    private void HandlerRoomChange(Room room)
    {
        CurrentRoom = room;
    }
}
