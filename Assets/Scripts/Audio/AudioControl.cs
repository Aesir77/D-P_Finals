using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    [Header("UI Sliders")]
    public Slider musicSlider, inGameMusicSlider;
    public Slider sfxSlider, inGameSFXSlider;

    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    // Names of the exposed parameters in your AudioMixer
    public string musicParam = "MusicVolume";
    public string sfxParam = "SFXVolume";
    public string inGameMusicParam = "InGameMusicVolume";
    public string inGameSFXParam = "InGameSFXVolume";

    // dB Range
    private const float minDB = -15f;
    private const float maxDB = 5f;

    void Start()
    {
        // Load saved values (0 to 1)
        float savedMusic = PlayerPrefs.GetFloat(musicParam, 0.5f);
        float savedSFX = PlayerPrefs.GetFloat(sfxParam, 0.5f);
        float savedInGameMusic = PlayerPrefs.GetFloat(inGameMusicParam, 0.5f);
        float savedInGameSFX = PlayerPrefs.GetFloat(inGameSFXParam, 0.5f);

        // Apply to sliders
        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;
        inGameMusicSlider.value = savedInGameMusic;
        inGameSFXSlider.value = savedInGameSFX;

        // Apply to AudioMixer
        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);
        SetInGameMusicVolume(savedInGameMusic);
        SetInGameSFXVolume(savedInGameSFX);

        // Add listeners
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        inGameMusicSlider.onValueChanged.AddListener(SetInGameMusicVolume);
        inGameSFXSlider.onValueChanged.AddListener(SetInGameSFXVolume);
    }

    private void SetMusicVolume(float value)
    {
        float dB = Mathf.Lerp(minDB, maxDB, value); // Map 0-1 to -15 to +5
        audioMixer.SetFloat(musicParam, dB);
        PlayerPrefs.SetFloat(musicParam, value);
    }

    private void SetSFXVolume(float value)
    {
        float dB = Mathf.Lerp(minDB, maxDB, value);
        audioMixer.SetFloat(sfxParam, dB);
        PlayerPrefs.SetFloat(sfxParam, value);
    }

    private void SetInGameMusicVolume(float value)
    {
        float dB = Mathf.Lerp(minDB, maxDB, value);
        audioMixer.SetFloat(inGameMusicParam, dB);
        PlayerPrefs.SetFloat(inGameMusicParam, value);
    }

    private void SetInGameSFXVolume(float value)
    {
        float dB = Mathf.Lerp(minDB, maxDB, value);
        audioMixer.SetFloat(inGameSFXParam, dB);
        PlayerPrefs.SetFloat(inGameSFXParam, value);
    }
}