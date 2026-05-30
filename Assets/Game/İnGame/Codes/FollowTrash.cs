using UnityEngine;

public class FollowTrash : MonoBehaviour
{
    public static int toplanan_cop = 0;
    public Transform hedef;       
     private float hiz = 5f;       
    private float menzil = 3f;


    void Start()
    {
        toplanan_cop = 0;
    }


    void Update()
    {
        if (hedef == null) return;

        bool GunMode = MoveCode.GunMode;

        float mesafe = Vector2.Distance(transform.position, hedef.position);

        if (mesafe < menzil && GunMode == true)
        {

            transform.position = Vector2.MoveTowards(
                transform.position, 
                hedef.position, 
                hiz * Time.deltaTime
            );

        }
    }

private void OnTriggerEnter2D(Collider2D Player)
{
    bool GunMode = MoveCode.GunMode;
    if (Player.CompareTag("Player") && GunMode == true)
    {

        toplanan_cop = toplanan_cop + 1;
        print($"Çöp toplandı! {toplanan_cop} ");
   

        Destroy(gameObject);

    }
}
}


