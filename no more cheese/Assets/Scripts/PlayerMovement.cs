using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpCutoff;
    [SerializeField] private float jumpBuffer;
    private Rigidbody2D body;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.linearVelocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            jump();
        }

        if(Input.GetButtonUp("Jump") && body.linearVelocity.y > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * jumpCutoff);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, jumpBuffer, groundLayer);
    }

    private void jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
