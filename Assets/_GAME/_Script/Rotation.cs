using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speedX, speedY, speedZ;

    void FixedUpdate()
    {
        transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime) ;
    }
}
