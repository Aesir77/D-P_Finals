using UnityEngine;
using TMPro;

public class Rat_remaining : MonoBehaviour
{
    public string EnemyTag = "Rat";
    public TMP_Text ratsRemaining;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }

}
