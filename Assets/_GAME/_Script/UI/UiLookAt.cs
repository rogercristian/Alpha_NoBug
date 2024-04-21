using UnityEngine;

public class UiLookAt : MonoBehaviour
{
    private void LateUpdate()
    {

        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward);
    }
}
