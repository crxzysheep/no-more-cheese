using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpIncrease;
    [SerializeField] private float jumpBuffer;
    private Rigidbody2D body;


    [SerializeField] private BoxCollider2D groundCheck;
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
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * jumpIncrease);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundLayer).Length > 0;
    }

    private void jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
    }
}
