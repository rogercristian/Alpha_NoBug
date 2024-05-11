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
    [SerializeField] bool canJump;
    private bool canMove = true;    

    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponentInParent<InputManager>();
        animator = GetComponentInParent<Animator>();

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
    }


    void Update()
    {

        if (!canMove)
        {
            animator.SetFloat("Direction", 0f);
            return;
        }

        input = inputManager.GetMoveDirection();

        if (rb.velocity.y <= 0)
        {
            rb.velocity = Vector3.up * gravityValue;
            animator.SetBool("Jump",false);
        }

        if (inputManager.GetMoveDirection() == Vector2.zero && IsGrounded())
            animator.SetFloat("Direction", direction.magnitude); animator.SetBool("Jump", false);
      
        if (!IsGrounded())
            animator.SetBool("Jump", true);
       
        else if (!IsGrounded() && inputManager.GetMoveDirection() != Vector2.zero)
            animator.SetBool("Jump", true);
        else if(IsGrounded())
            animator.SetBool("Jump", false);
        // walk animation
        if (inputManager.GetMoveDirection() != Vector2.zero)
            animator.SetFloat("Direction", direction.magnitude);


        CanShootAnim();
        Debug.Log(Physics.Raycast(transform.position, Vector3.down, groundedDistance));
        Debug.DrawRay(transform.position, Vector3.down, Color.red, groundedDistance);
        // se pulo estiver habilitado:
        if(canJump) Jumping();
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
            // jump animation
        }
    }

    private void CanShootAnim()
    {
        if (inputManager.GetInteractPressed())
        {
            animator.SetBool("Shoot", true);
        }
        if (!inputManager.GetInteractPressed())
        {
            animator.SetBool("Shoot", false);
        }        
    }
}
