using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        //Switch Camera
    }

    public void Settings(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void Quit()
    {

#if UNITY_EDITOR
        // Stop playing the scene in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
    // Quit the application
    Application.Quit();
    }
#endif

    }
}

