using Unity.VisualScripting;
using UnityEngine;

public class Keybinds : MonoBehaviour
{
    [SerializeField] private GameObject Settings_View;
    [SerializeField] private MonoBehaviour PlayerMovementScript; 
   
    void Start()
    {
        Settings_View = GameObject.Find("INGAMESETTINGS");
        PlayerMovementScript = GameObject.Find("PlayerCapsule").GetComponent<MonoBehaviour>();
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
                if (PlayerMovementScript != null)
                {
                    PlayerMovementScript.enabled = false; // Disable player movement script when settings are open
                }
            }
        }
    }
}
