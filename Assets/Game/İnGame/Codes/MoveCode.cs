using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCode : MonoBehaviour
{
    public float speed = 5f;

    public static bool GunMode = false;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    void Update()
    {
        float moveX = 0;
        float moveY = 0;

        var keyboard = Keyboard.current;

        if (keyboard.wKey.isPressed)
        {
            moveY = 1;
            this.GetComponent<Animator>().SetBool("isRunning", true);
        }

        if (keyboard.sKey.isPressed)
        {
            moveY = -1;
            this.GetComponent<Animator>().SetBool("isRunning", true);
        }

        if (keyboard.aKey.isPressed) 
        {
            moveX = -1;
            Flip(true);
            this.GetComponent<Animator>().SetBool("isRunning", true);
        }

        if (keyboard.dKey.isPressed) 
        {
            moveX = 1;
            Flip(false);
            this.GetComponent<Animator>().SetBool("isRunning", true);
        }

        if (keyboard.eKey.wasPressedThisFrame)
        {
            if (this.GetComponent<Animator>().GetBool("isDrawingGun") == false && this.GetComponent<Animator>().GetBool("isRunning") == false)
            {
                this.GetComponent<Animator>().SetBool("isDrawingGun", true);
                GunMode = true;
                
            }

            else 
            {
                this.GetComponent<Animator>().SetBool("isDrawingGun", false);
                GunMode = false;
                
            }

        }

        else if (!keyboard.wKey.isPressed && !keyboard.sKey.isPressed && !keyboard.aKey.isPressed && !keyboard.dKey.isPressed && !keyboard.eKey.isPressed)
        {
            this.GetComponent<Animator>().SetBool("isRunning", false);
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