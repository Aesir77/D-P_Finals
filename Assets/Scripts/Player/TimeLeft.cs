using UnityEngine;
using TMPro;

public class TimeLeft : MonoBehaviour
{
    public TMP_Text timeLeftText; // Reference to the UI Text component
    public float timeLeft = 300f; // Time left in seconds
    public GameObject GameOverScreen;

    private bool hasStarted = false;
    private bool gameOver = false;

     void Start()
    {
      
        GameOverScreen = GameObject.Find("GAME OVER UI");
        GameOverScreen.SetActive(false);
    }
    void Update()
    {
        if (!hasStarted) return;
        {
            if (gameOver) return;

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
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
        gameOver = true; 
        Time.timeScale = 0f; //pause
        timeLeftText.text = "Game Over! Time's Up!"; 
        GameOverScreen.SetActive(true); 
        
    }


public void StartTimer()
    {
        hasStarted = true; 
    }
}

