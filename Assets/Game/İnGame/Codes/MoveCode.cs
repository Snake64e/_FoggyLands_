using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    void Update()
    {
        float moveX = 0;
        float moveY = 0;

        var keyboard = Keyboard.current;

        if (keyboard.wKey.isPressed) moveY = 1;
        if (keyboard.sKey.isPressed) moveY = -1;

        if (keyboard.aKey.isPressed) 
        {
            moveX = -1;
            Flip(true); 
        }
        if (keyboard.dKey.isPressed) 
        {
            moveX = 1;
            Flip(false);
        }

        moveInput = new Vector2(moveX, moveY).normalized;
    }

  
    void Flip(bool solaMi)
    {
        Vector3 localScale = transform.localScale;

        if (solaMi)
            localScale.x = -Mathf.Abs(localScale.x); 
        else
            localScale.x = Mathf.Abs(localScale.x);  

        transform.localScale = localScale;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }
}