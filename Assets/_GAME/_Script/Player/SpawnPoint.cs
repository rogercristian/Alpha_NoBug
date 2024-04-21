using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private int id;
    Vector3 playerTransform;
    private void OnEnable()
    {
        GameEvents.Instance.OnReposition += Handler_OnReposition;
        playerTransform = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnReposition -= Handler_OnReposition;
    }
    private void Handler_OnReposition(int id)
    {
        if (this.id == id)
        {
            MovingPlayer Moving = FindObjectOfType<MovingPlayer>();

            if (Moving != null)
            {
                Moving.transform.position = playerTransform;
                Moving.transform.rotation = transform.rotation;
            }

        }
    }
    private void Update()
    {
        playerTransform = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
}
