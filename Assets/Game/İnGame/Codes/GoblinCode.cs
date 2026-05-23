using UnityEngine;

public class YerliCode : MonoBehaviour
{
    private float speed = 2f;

    public float kovalamaHizi = 3f;
    public Rigidbody2D rb;
    public Transform hedef;
    
    private Vector2 moveInput;

    private bool kovaliyor = false;

    void Start()
    {
        // HATA 1: Olmayan "YönBelirle" yerine mantığı yazdığın "kovala" fonksiyonu çağrıldı
        InvokeRepeating("kovala", 0f, 2f);
    }

    void Update()
    {
        float mesafe = Vector2.Distance(transform.position, hedef.position);
        
        if (mesafe <= 4f)
        {
            kovaliyor = true;
            // HATA 2: Mesafe yakınken rastgele yön seçen kovala() yerine, hedefi takip eden fonksiyon çağrıldı
            KovalamaYonuBelirle();
        }
        else
        {
            kovaliyor = false;
        }
    }

    void FixedUpdate()
    {
        // HATA 4: Eğer kovalıyorsa kovalamaHizi, kovalamıyorsa normal speed kullanması sağlandı
        float mevcutHiz = kovaliyor ? kovalamaHizi : speed;
        rb.linearVelocity = moveInput * mevcutHiz;
    }

    void kovala()
    {
        // HATA 3: !kovaliyor kontrolü artık doğru çalışıyor (Kovalıyorsa rastgele yön seçmeyecek)
        if (!(kovaliyor))
        {
            float moveX = 0;
            float moveY = 0;

            string[] yöns = { "W", "A", "S", "D", "Dur" }; 
            string seçilenYön = yöns[Random.Range(0, yöns.Length)];

            if (seçilenYön == "W") moveY = 1;
            if (seçilenYön == "S") moveY = -1;
            if (seçilenYön == "A") 
            {
                moveX = -1;
                Flip(true); 
            }
            if (seçilenYön == "D") 
            {
                moveX = 1;
                Flip(false);
            }
            if (seçilenYön == "Dur")
            {
                moveX = 0;
                moveY = 0;
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