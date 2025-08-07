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

    #region EverythingElse
    [SerializeField] private GameObject PlayerUI;
    [SerializeField] private GameObject RemainingUI;
    [SerializeField] private GameObject In_Game_Settings;
    [SerializeField] private MonoBehaviour PlayerMovement;

    #endregion
    void Start()
    {
        #region Finding the GameObjects
        Main_Menu = GameObject.Find("Main_Screen");
        PlayerFreeze = GameObject.Find("PlayerCapsule");
        SettingsView = GameObject.Find("SETTINGS");
        spawn_Manager = GameObject.Find("SpawnPoint").GetComponent<Spawn_Manager>();
        PlayerUI = GameObject.Find("Player UI");
        RemainingUI = GameObject.Find("RemainingUI");
        In_Game_Settings = GameObject.Find("INGAMESETTINGS");
        PlayerMovement = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();

        DialogueBox = GameObject.Find("DIALOGUE_BOX").GetComponent<Dialogue_and_Timer>();
        Dialogue_andTimer = GameObject.Find("HIDING_TIMER(For Player)");

        #endregion

        Dialogue_andTimer.SetActive(false);
        RemainingUI.SetActive(false);
        PlayerUI.SetActive(false);
        In_Game_Settings.SetActive(false);
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
        RemainingUI.SetActive(true);
        Main_Menu.SetActive(false);
        DialogueBox.StartCoroutine(DialogueBox.PlayDialogue()); //Dialogue and timer on game start
        spawn_Manager.SpawnRats(); //spawn Rats on game start
       

    }

    public void ReturnToMainMenu()
    {
        Main_Menu.SetActive(true);
        Camera_Manager.SwitchCamera(MainMenuCam);
        StarterAssetsInputs.SetCursorState(false);
        PlayerFreeze.SetActive(false);
        PlayerUI.SetActive(false);
        Dialogue_andTimer.SetActive(false);
        RemainingUI.SetActive(false);
        spawn_Manager.ClearRats(); // Clear all spawned rats when returning to main menu
        In_Game_Settings.SetActive(false);
        Time.timeScale = 1f; // Resume the game if paused
    }

    public void Settings()
    {
        SettingsView.SetActive(true);
    }

    public void ExitSettings()
    {
        SettingsView.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void ExitIngameSettings() //for IngameSettings that has the return back to main menu button
    {
        In_Game_Settings.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        PlayerMovement.enabled = true; // Enable player movement script when settings are closed
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

