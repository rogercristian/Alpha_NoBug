using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    [SerializeField] DialogData dialogData;
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] bool recorrentDialog = false;

    private void Start()
    {
        GameEvents.Instance.OnFinishDialog += HandlerOnFinishDialog;
    }

    private void HandlerOnFinishDialog()
    {
        if (!recorrentDialog)
            sphereCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        MovingPlayer movingPlayer = GetComponent<MovingPlayer>();
        if (other.TryGetComponent<MovingPlayer>(out movingPlayer))
        {
            GameEvents.Instance.StartDialog(dialogData);
        }
    }

}
