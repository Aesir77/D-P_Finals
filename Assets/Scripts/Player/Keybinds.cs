using Unity.VisualScripting;
using UnityEngine;

public class Keybinds : MonoBehaviour
{
    [SerializeField] private GameObject Settings_View;
    [SerializeField] private MonoBehaviour PlayerMovementScript;
    [SerializeField] private Player_Shoot PlayerShootScript;

    void Start()
    {
        Settings_View = GameObject.Find("INGAMESETTINGS");
        PlayerMovementScript = GameObject.Find("PlayerCapsule").GetComponent<MonoBehaviour>();
        PlayerShootScript = GameObject.Find("PlayerCapsule").GetComponent<Player_Shoot>();  
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Settings_View.activeSelf)
            {
                Settings_View.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f; // Resume the game
                PlayerShootScript.enabled = true; // Enable player shooting script when settings are closed
                if (PlayerMovementScript != null)
                {
                    PlayerMovementScript.enabled = true; // Enable player movement script when settings are closed
                }
            }
            else
            {
                Settings_View.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f; // Pause the game
                PlayerShootScript.enabled = false; // Disable player shooting script when settings are open
                if (PlayerMovementScript != null)
                {
                    PlayerMovementScript.enabled = false; // Disable player movement script when settings are open
                }
            }
        }
    }
}
