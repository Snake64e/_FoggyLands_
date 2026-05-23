using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager kullanımı için gerekli

public class Scene_Controller : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update() 
    {
    
    }
    // Geçilecek sahnenin adını editörden girmek için fonksiyon
    public void ChangeScene(string Main_Game)
    {
        SceneManager.LoadScene(Main_Game);
    }
}
