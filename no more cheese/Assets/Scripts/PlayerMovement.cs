using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour // also all player actions
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
        float horizonalInput = Input.GetAxis("Horizontal");

        // default movement
        body.linearVelocity = new Vector2(horizonalInput* moveSpeed, body.linearVelocity.y);

        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            jump();
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) && body.linearVelocity.y > 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * jumpIncrease);
        }

        //animations
        if (horizonalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizonalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
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
