using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using NUnit.Framework;
using System.Collections.Generic;

public class Menu_Script : MonoBehaviour
{
    [SerializeField] private GameObject Main_Menu;
    void Start()
    {
       
    }

    
    public void StartGame()
    {
       
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

