using UnityEngine;

public class FollowSeed : MonoBehaviour
{
    public static int toplanan_tohum = 0;
    public Transform hedef;       
     private float hiz = 5f;       
    private float menzil = 3f; 

    void Update()
    {
        if (hedef == null) return;

        float mesafe = Vector2.Distance(transform.position, hedef.position);

        if (mesafe < menzil)
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

    if (Player.CompareTag("Player"))
    {

        toplanan_tohum = toplanan_tohum + 1;
        print($"Tohum toplandı! {toplanan_tohum} ");
   

        Destroy(gameObject);

    }
}
}


