using UnityEngine;
using UnityEngine.InputSystem;

public class AnCode : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // 1. Mutlaka bileşeni koda tanıtman lazım
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var ky = Keyboard.current;


        if (ky.wKey.isPressed || ky.aKey.isPressed || ky.sKey.isPressed || ky.dKey.isPressed) 
           { animator.CrossFade("Chacracter Animation", 0.1f); }

        else animator.Play("Chacracter Animation", 0, 0f);

    }
}