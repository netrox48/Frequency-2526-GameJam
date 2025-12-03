using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSController : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float groundCheckDistance = 1.1f;
    public LayerMask groundMask;

    [Header("Mouse Ayarları")]
    public float mouseSensitivity = 100f;
    public Transform cameraHolder;
    private float xRotation = 0f;

    private Rigidbody rb;
    private Vector3 inputDir;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleInput();
        HandleJump();
    }

    void FixedUpdate()
    {
        Move();
        GroundCheck();
    }

    void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A, D
        float vertical = Input.GetAxisRaw("Vertical");     // W, S
        inputDir = (transform.right * horizontal + transform.forward * vertical).normalized;
    }

    void Move()
    {
        Vector3 move = inputDir * moveSpeed;
        Vector3 velocity = new Vector3(move.x, rb.velocity.y, move.z);
        rb.velocity = velocity;
    }

    void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Yukarı-aşağı sınırı

        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
