using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections.Generic;
using StarterAssets;

public class Menu_Script : MonoBehaviour
{
    #region Settings
    [SerializeField] private GameObject Main_Menu;
    [SerializeField] private GameObject PlayerFreeze;
    [SerializeField] private GameObject SettingsView;
    
    #endregion

    #region CameraSwitching
    public CinemachineVirtualCamera PlayerCam;
    public CinemachineVirtualCamera MainMenuCam;
    #endregion
    void Start()
    {
       Main_Menu = GameObject.Find("MAIN_MENU");
       PlayerFreeze = GameObject.Find("PlayerCapsule");
        SettingsView = GameObject.Find("SETTINGS");

        PlayerFreeze.SetActive(false);
        SettingsView.SetActive(false);
    }

    
    public void StartGame()
    {
       Camera_Manager.SwitchCamera(PlayerCam);
        StarterAssetsInputs.SetCursorState(true);
        Main_Menu.SetActive(false);
        PlayerFreeze.SetActive(true);
    }

    public void Settings()
    {
       SettingsView.SetActive(true);
    }

    public void ExitSettings()
    {
        SettingsView.SetActive(false);
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

