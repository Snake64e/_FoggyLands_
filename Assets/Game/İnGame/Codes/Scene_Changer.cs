using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float changetime;
    public string sceneName;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        changetime -= Time.deltaTime;
        if(changetime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
        
}
