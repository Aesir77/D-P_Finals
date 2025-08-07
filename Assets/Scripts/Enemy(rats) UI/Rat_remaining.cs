using UnityEngine;
using TMPro;

public class Rat_remaining : MonoBehaviour
{
    public string EnemyTag = "Rat";
    public TMP_Text ratsRemaining;
    public GameObject GameWinScreen;

    private bool hasWon = false;
    private bool gameStarted = false;

    void Start()
    {
        GameWinScreen = GameObject.Find("GAME WIN UI");
        GameWinScreen.SetActive(false);
    }
    void Update()
    {
        if (!gameStarted) return;
        {

            GameObject[] rats = GameObject.FindGameObjectsWithTag(EnemyTag);
            int RatCount = rats.Length;

            if (ratsRemaining != null)
            {
                ratsRemaining.text = "Rats Remaining: " + RatCount.ToString();
            }
            else
            {
                Debug.LogWarning("ratsRemaining TextMeshProUGUI is not assigned in the inspector.");
            }

            if (RatCount <= 0 && !hasWon)
            {
                GameWin();
            }
        }
    }


    void GameWin()
    {
        hasWon = true;
        GameWinScreen.SetActive(true);
        Time.timeScale = 0f; //pause
    }

    public void RatRemaining()
    {
        gameStarted = true;
    }

}
