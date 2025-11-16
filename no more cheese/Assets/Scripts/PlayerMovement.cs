using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour // also all player actions
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpIncrease;
    [SerializeField] private float jumpBuffer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // default movement
        

        // jump
        if (wallJumpCooldown > jumpBuffer)
        {

            body.linearVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 3;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) && body.linearVelocity.y > 0f)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * jumpIncrease);
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }

        //animations
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
        }
       else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * moveSpeed, jumpPower);
            }
            wallJumpCooldown = 0;
        }
    }
}
