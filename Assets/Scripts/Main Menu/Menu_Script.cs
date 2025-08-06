using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine.Playables;

public class Menu_Script : MonoBehaviour
{
    #region Settings
    [SerializeField] private GameObject Main_Menu;
    [SerializeField] private GameObject PlayerFreeze;
    [SerializeField] private GameObject SettingsView;
    [SerializeField] private GameObject PlayerUI;

    #endregion
    #region CameraSwitching
    public CinemachineVirtualCamera PlayerCam;
    public CinemachineVirtualCamera MainMenuCam;
    #endregion
    #region EnemySpawn and Timer
  [SerializeField] private Spawn_Manager spawn_Manager;
    [SerializeField] private Dialogue_and_Timer DialogueBox;
  [SerializeField] private GameObject Dialogue_andTimer;
    
    #endregion
    void Start()
    {
        Main_Menu = GameObject.Find("Main_Screen");
        PlayerFreeze = GameObject.Find("PlayerCapsule");
        SettingsView = GameObject.Find("SETTINGS");
        spawn_Manager = GameObject.Find("SpawnPoint").GetComponent<Spawn_Manager>();
        PlayerUI = GameObject.Find("Player UI");

        DialogueBox = GameObject.Find("DIALOGUE_BOX").GetComponent<Dialogue_and_Timer>();
        Dialogue_andTimer = GameObject.Find("HIDING_TIMER(For Player)");


        Dialogue_andTimer.SetActive(false);

        PlayerUI.SetActive(false);
        PlayerFreeze.SetActive(false);
        SettingsView.SetActive(false);
    }


    public void StartGame()
    {
        Camera_Manager.SwitchCamera(PlayerCam);
        StarterAssetsInputs.SetCursorState(true);
        PlayerFreeze.SetActive(true);
        PlayerUI.SetActive(true);
        Dialogue_andTimer.SetActive(true);
        Main_Menu.SetActive(false);
        DialogueBox.StartCoroutine(DialogueBox.PlayDialogue()); //Dialogue and timer on game start
        spawn_Manager.SpawnRats(); //spawn Rats on game start
       

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

