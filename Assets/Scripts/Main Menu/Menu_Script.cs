using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine.Playables;
using Unity.VisualScripting;


public class Menu_Script : MonoBehaviour
{
    #region Settings
    [SerializeField] private GameObject Main_Menu;
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
    [SerializeField] private Rat_remaining EnemyLeftUI; //this is needed so that it doesnt automatically show the game win screen because the rats is 0
    [SerializeField] private MonoBehaviour movementScript;
    [SerializeField] private GameObject GameWin, GameOver;
    [SerializeField] private Player_Shoot PlayerShootScript;



    #endregion
    void Start()
    {
        #region Finding the GameObjects
       
        GameOver = GameObject.Find("GAME OVER UI");
        GameWin = GameObject.Find("GAME WIN UI");
        Main_Menu = GameObject.Find("Main_Screen");
        SettingsView = GameObject.Find("SETTINGS");
        spawn_Manager = GameObject.Find("Spawn Manager (Spawnpoint)").GetComponent<Spawn_Manager>();
        PlayerUI = GameObject.Find("Player UI");
        RemainingUI = GameObject.Find("RemainingUI");
        In_Game_Settings = GameObject.Find("INGAMESETTINGS");
        PlayerMovement = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
        EnemyLeftUI = GameObject.Find("EnemyLeft_UI").GetComponent<Rat_remaining>();
        DialogueBox = GameObject.Find("DIALOGUE_BOX").GetComponent<Dialogue_and_Timer>();
        Dialogue_andTimer = GameObject.Find("HIDING_TIMER(For Player)");
        movementScript = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
        PlayerShootScript = GameObject.Find("PlayerCapsule").GetComponent<Player_Shoot>();

        #endregion


        movementScript.enabled = false;
        Dialogue_andTimer.SetActive(false);
        RemainingUI.SetActive(false);
        PlayerUI.SetActive(false);
        In_Game_Settings.SetActive(false);
        SettingsView.SetActive(false);


    }


    public void StartGame()
    {
        Camera_Manager.SwitchCamera(PlayerCam);
        StarterAssetsInputs.SetCursorState(true);
        PlayerUI.SetActive(true);
        Dialogue_andTimer.SetActive(true);
        RemainingUI.SetActive(true);
        Main_Menu.SetActive(false);
        DialogueBox.StartCoroutine(DialogueBox.PlayDialogue()); //Dialogue and timer on game start
        spawn_Manager.SpawnRats(); //spawn Rats on game start
        EnemyLeftUI.RatRemaining(); // Initialize the rats remaining UI
       

    }

    public void ReturnToMainMenu()
    {
        Main_Menu.SetActive(true);
        Camera_Manager.SwitchCamera(MainMenuCam);
        StarterAssetsInputs.SetCursorState(false);
        PlayerUI.SetActive(false);
        Dialogue_andTimer.SetActive(false);
        RemainingUI.SetActive(false);
        spawn_Manager.ClearRats(); // Clear all spawned rats when returning to main menu
        In_Game_Settings.SetActive(false);
        GameWin.SetActive(false); 
        GameOver.SetActive(false);
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
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        PlayerShootScript.enabled = true; // Enable player shooting script when settings are closed

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

    //Game over screen
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}

