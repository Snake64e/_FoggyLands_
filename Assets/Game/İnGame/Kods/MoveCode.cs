using UnityEngine;
using UnityEngine.InputSystem; // Bu satırı eklemeyi unutma!

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    void Update()
    {
        // "isPressed" mantığının en basit hali
        float moveX = 0;
        float moveY = 0;

        var keyboard = Keyboard.current;

        if (keyboard.wKey.isPressed) moveY = 1;
        if (keyboard.sKey.isPressed) moveY = -1;
        if (keyboard.aKey.isPressed) moveX = -1;
        if (keyboard.dKey.isPressed) moveX = 1;

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }
}