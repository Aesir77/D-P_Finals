using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Server : MonoBehaviour
{
    [Header("Server Settings")]
    public string serverUrl = "https://localhost:7047/api/data"; // Your API endpoint

    [Header("References")]
    public FirstPersonController firstPersonController; // Assign in inspector
    public Player_Health playerHealth;                  // Assign in inspector
    public Rat_remaining ratRemaining;                  // Assign in inspector

    void Start()
    {
        // Start sending updates every 1 second
        InvokeRepeating(nameof(SendPlayerData), 1f, 1f);
    }

    void SendPlayerData()
    {
        StartCoroutine(SendDataCoroutine());
    }

    IEnumerator SendDataCoroutine()
    {
        PlayerData data = new PlayerData()
        {
            playerName = firstPersonController.gameObject.name,
            playerHealth = playerHealth.currentHealth,
            score = ratRemaining.RatCount,
            playerPosition = new Position()
            {
                X = firstPersonController.transform.position.x,
                Y = firstPersonController.transform.position.y,
                Z = firstPersonController.transform.position.z
            }
        };

        string json = JsonUtility.ToJson(data);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(serverUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error Sending Data: " + request.error);
        }
        else
        {
            Debug.Log("Data sent successfully!");
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int playerHealth;
    public int score;
    public Position playerPosition;
}

[System.Serializable]
public class Position
{
    public float X;
    public float Y;
    public float Z;
}
