using UnityEngine;

public class YerliMove : MonoBehaviour
{
    private float speed = 2f;

    public float kovalamaHizi = 3f;
    public Rigidbody2D rb;
    public Transform hedef;
    
    private Vector2 moveInput;

    private bool kovaliyor = false;

    void Start()
    {

        InvokeRepeating("kovala", 0f, 2f);
    }

void Update()
{
  


    float mesafe = Vector2.Distance(transform.position, hedef.position);
    
    if (mesafe <= 4f && !(YerliHappy.Happiness))
    {
        kovaliyor = true;
        KovalamaYonuBelirle();
    }
    else
    {
        kovaliyor = false;
    }
}

    void FixedUpdate()
    {

        float mevcutHiz = kovaliyor ? kovalamaHizi : speed;
        rb.linearVelocity = moveInput * mevcutHiz;
    }

    void kovala()
    {


        if (!(kovaliyor) )
        {
            float moveX = 0;
            float moveY = 0;

            string[] yöns = { "W", "A", "S", "D", "Dur" }; 
            string seçilenYön = yöns[Random.Range(0, yöns.Length)];

            if (seçilenYön == "W")
            {
                moveY = 1;
                this.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (seçilenYön == "S")
            {
                moveY = -1;
                this.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (seçilenYön == "A") 
            {
                moveX = -1;
                Flip(true);
                this.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (seçilenYön == "D") 
            {
                moveX = 1;
                Flip(false);
                this.GetComponent<Animator>().SetBool("isRunning", true);
            }
            if (seçilenYön == "Dur")
            {
                moveX = 0;
                moveY = 0;
                this.GetComponent<Animator>().SetBool("isRunning", false);
            }

            moveInput = new Vector2(moveX, moveY).normalized;
            
        }
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

    void KovalamaYonuBelirle()
    {
        Vector2 yon = (hedef.position - transform.position).normalized;
        moveInput = yon;

        if (moveInput.x < 0) Flip(true);
        else if (moveInput.x > 0) Flip(false);
    }
}