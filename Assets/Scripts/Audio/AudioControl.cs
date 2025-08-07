using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public Scrollbar musicScrollbar, inGamemusicScrollbar; 
    public Scrollbar sfxScrollbar, inGamesfxScrollbar; 
    public AudioSource musicAudioSource, sfxAudioSource; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        float savedInGameMusicVolume = PlayerPrefs.GetFloat("InGameMusicVolume", 1f);
        float savedInGameSFXVolume = PlayerPrefs.GetFloat("InGameSFXVolume", 1f);


        musicScrollbar.value = savedMusicVolume;
        sfxScrollbar.value = savedSFXVolume;

        musicAudioSource.volume = savedMusicVolume;
        sfxAudioSource.volume = savedSFXVolume;

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetmusicVolume(float value)
    {
        if ( musicAudioSource != null)
        {
            musicAudioSource.volume = value;
            PlayerPrefs.SetFloat("MusicVolume", value); // Save it
        }
    }

    public void SetsfxVolume(float value)
    {
        if (sfxAudioSource != null)
        {
            sfxAudioSource.volume = value;
            PlayerPrefs.SetFloat("SFXVolume", value); // Save it
        }
    }

    public void SetInGameMusicVolume(float value)
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.volume = value;
            PlayerPrefs.SetFloat("InGameMusicVolume", value); // Save it
        }
    }

    public void SetInGameSFXVolume(float value)
    {
        if (sfxAudioSource != null)
        {
            sfxAudioSource.volume = value;
            PlayerPrefs.SetFloat("InGameSFXVolume", value); // Save it
        }
    }
}
