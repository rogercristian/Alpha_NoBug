using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    [SerializeField] float speed = 10.0f; // Adjust the movement speed as needed
    Rigidbody rb;
    InputManager inputManager;
    Vector2 input;
    Vector3 direction;
    float currentSpeed;
    [SerializeField] float smoothTime = 0.05f;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float groundedDistance = 1.0f;

    private bool canMove = true;
    // Vector3 downVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponentInParent<InputManager>();

        GameEvents.Instance.OnStartDialog += HandlerOnStartDialog;
        GameEvents.Instance.OnFinishDialog += HandlerOnFinishDialog;
    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnStartDialog -= HandlerOnStartDialog;
        GameEvents.Instance.OnFinishDialog -= HandlerOnFinishDialog;
    }
    private void HandlerOnStartDialog(DialogData dialogData)
    {
        canMove = false;
    }
    private void HandlerOnFinishDialog()
    {
        canMove = true;
      //  direction = input.x * Vector3.right + input.y * Vector3.forward;

    }


    void Update()
    {
        if (!canMove)
        {          
            return;
        }

        if (rb.velocity.y <= 0)
        {
            rb.velocity = Vector3.up * gravityValue;
        }

        input = inputManager.GetMoveDirection();

        Jumping();

        Debug.Log(Physics.Raycast(transform.position, Vector3.down, groundedDistance));
        Debug.DrawRay(transform.position, Vector3.down, Color.red, groundedDistance);
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundedDistance);

    }
    void LookAt()
    {
        if (input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentSpeed, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    void FixedUpdate()
    {
        MoveCharacter();
        LookAt();
    }
    void MoveCharacter()
    {
        if (!canMove)
        {
            transform.Translate(Vector3.zero);
            return;
        }
        direction = input.x * Vector3.right + input.y * Vector3.forward;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    void Jumping()
    {
        // Changes the height position of the player..
        if (inputManager.GetSubmitPressed() && IsGrounded())
        {
            rb.velocity = Vector3.up * jumpHeight;
        }
    }
}
