using UnityEngine;

public class Rat_Sound : MonoBehaviour
{
    [SerializeField] private AudioClip ratSound;
    [SerializeField] private AudioSource ratSoundSource;
    [SerializeField] private float soundInterval = 80f;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ratSoundSource.PlayOneShot(ratSound); // Play the rat sound immediately at the start
        ratSoundSource.GetComponent<AudioSource>(); // Ensure the AudioSource is assigned

        timer = soundInterval; // Initialize the timer to the sound interval
        if (ratSound == null)
        {
            Debug.LogWarning("Rat sound clip is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ratSoundSource == null || ratSoundSource.clip == null) return;

        timer -= Time.deltaTime; // Decrease the timer by the time since the last frame

        if (timer >= 0f)
        {
            Debug.Log("Current Timer: " + timer);
            ratSoundSource.Play(); // Play the rat sound
            timer = soundInterval; // Reset the timer to the sound interval
        }
    }
}
