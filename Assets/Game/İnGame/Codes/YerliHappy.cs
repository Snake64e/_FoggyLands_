using UnityEngine;
using UnityEngine.InputSystem;

public class YerliHappy : MonoBehaviour
{
    public Transform hedef;
    public static bool Happiness;

    void Start()
    {
        Happiness = false;
    }

    void Update()
    {



        float mesafe = Vector3.Distance(transform.position, hedef.position);

        if (mesafe <= 4f && Keyboard.current.fKey.wasPressedThisFrame && FollowSeed.toplanan_tohum > 0)
        {
            Happiness = true;
            FollowSeed.toplanan_tohum -= 1;
            Debug.Log($"Yerli mutlu oldu! tohum: {FollowSeed.toplanan_tohum}"); 
        }
    }
}