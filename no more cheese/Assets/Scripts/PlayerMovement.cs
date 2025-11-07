using UnityEngine;

public class PlayerMovement
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
}
