using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerOne;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed;
    // [SerializeField] CinemachineVirtualCamera virtualCamera;
    //private Vector3 gizmoPos;

    private void OnEnable()
    {
        GameEvents.Instance.OnSeekPlayer += Handler_OnSeekPlayer;
    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnSeekPlayer -= Handler_OnSeekPlayer;
    }
    private void Handler_OnSeekPlayer()
    {
        playerOne = ManualPlayerJoin.instance.playerList[0].GetComponent<PlayerInputHandler>().GetMovingPlayer().transform;
        transform.position = playerOne.position + offset;

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (playerOne/* != null && ManualPlayerJoin.instance.playerList.Count < 2*/)
        {
            Vector3 desiredPosition = playerOne.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
        //else if (ManualPlayerJoin.instance.playerList.Count >= 2)
        //{
        //    Vector3 desiredPosition = FindCore() + offset;
        //    Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //    transform.position = smoothPosition;
        //    gizmoPos = FindCore();

        //}
    }

    //public Vector3 FindCore()
    //{
    //    var totalX = 0f; var totalY = 0f; var totalZ = 0f;
    //    foreach (var player in ManualPlayerJoin.instance.playerList)
    //    {
    //        totalX += player.GetComponent<PlayerInputHandler>().GetMovingPlayer().transform.position.x;
    //        totalY += player.GetComponent<PlayerInputHandler>().GetMovingPlayer().transform.position.y;
    //        totalZ += player.GetComponent<PlayerInputHandler>().GetMovingPlayer().transform.position.z;
    //    }

    //    var centerX = totalX / ManualPlayerJoin.instance.playerList.Count;
    //    var centerY = totalY / ManualPlayerJoin.instance.playerList.Count;
    //    var centerZ = totalZ / ManualPlayerJoin.instance.playerList.Count;

    //    return new Vector3(centerX, centerY, centerZ);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawCube(gizmoPos, new Vector3(1, 1, 1));
    //}
}
