using UnityEngine;
using UnityEngine.InputSystem;

public class SeedMaker : MonoBehaviour
{


    public static int Fidan = 0;

    public static bool GameFinish = false;

    void Start()
    {
        Fidan = 0;
        GameFinish = false;
    }
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.zKey.isPressed)
        {

            if (FollowSeed.toplanan_tohum > 0 && FollowTrash.toplanan_cop > 1)
            {
                while (FollowTrash.toplanan_cop > 2 && FollowSeed.toplanan_tohum > 1)
                {
                Fidan ++;
                FollowSeed.toplanan_tohum -= 1;
                FollowTrash.toplanan_cop -= 2;
                }


                Debug.Log($"fidan sayısı: {Fidan}");

                if (Fidan >= 30)
                {
                    print("oyun bitti");
                    GameFinish = true;
                }
            }

        }






    }

  
 
}