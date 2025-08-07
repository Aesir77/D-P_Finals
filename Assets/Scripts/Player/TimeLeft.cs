using StarterAssets;
using TMPro;
using UnityEngine;

public class TimeLeft : MonoBehaviour
{
    public TMP_Text timeLeftText; // Reference to the UI Text component
    public float timeLeft = 300f; // Time left in seconds
    public GameObject GameOverScreen, PlayerUI;
    [SerializeField] private MonoBehaviour movementScript;

    private bool hasStarted = false;
    private bool gameOver = false;

     void Start()
    {
        movementScript = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
        GameOverScreen = GameObject.Find("GAME OVER UI");
        GameOverScreen.SetActive(false);
        PlayerUI = GameObject.Find("Player UI");
    }
    void Update()
    {
        if (!hasStarted) return;
        {
            
            if (gameOver) return;

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                Debug.Log("Game Over");
                timeLeft = 0f;
                GameOver();

            }
            TimerDisplay();
        }
    }
   


    void TimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);
        timeLeftText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }

    

   public void GameOver()
    {
        PlayerUI.SetActive(false); // Hide the player UI
        gameOver = true; 
        Time.timeScale = 0f; //pause
        timeLeftText.text = "Game Over! Time's Up!"; 
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor    
        GameOverScreen.SetActive(true); 
        movementScript.enabled = false; // Disable player movement script when game is over

    }


public void StartTimer()
    {
        hasStarted = true; 
    }
    


}

