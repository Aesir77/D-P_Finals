using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private GameObject InGameSettings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InGameSettings = GameObject.Find("INGAMESETTINGS");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
