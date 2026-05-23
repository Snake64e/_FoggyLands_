using UnityEngine;

public class Random_Location : MonoBehaviour
{
   

    void Awake()
    {
        this.transform.Translate(Random.Range(-67,-9),Random.Range(-9,27),0);
    }
}
