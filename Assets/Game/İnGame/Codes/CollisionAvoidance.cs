using UnityEngine;

public class CollisionAvoidance : MonoBehaviour
{

    GameObject obj;
    bool isColliding = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true)
        {
            this.transform.Translate(Random.Range(-67, -9), Random.Range(-9, 27), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Cop"))
        {
            isColliding = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Ağaç") || collision.gameObject.name.StartsWith("Cop"))
        {
            isColliding = true;
        }
    }
}
