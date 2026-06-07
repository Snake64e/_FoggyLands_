using UnityEngine;

public class Random_Location : MonoBehaviour
{
   

    void Awake()
    {
        this.transform.Translate(Random.Range(-65,-9),Random.Range(-9,27),0);
    }
}
