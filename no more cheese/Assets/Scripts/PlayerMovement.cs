using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);
    }
}
