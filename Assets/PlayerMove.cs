using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 0.3f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool jumpPressed;
    private Vector3 inputDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        inputDir = new Vector3(h, 0, v).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("점프");
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        // 이동
        Vector3 velocity = inputDir * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        // 점프
        if (jumpPressed && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        jumpPressed = false;
    }

    private bool IsGrounded()
    {
        return true; // 임시로 항상 땅 위라고 가정
    }
}