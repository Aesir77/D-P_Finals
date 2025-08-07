using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;
using StarterAssets;

public class Dialogue_and_Timer : MonoBehaviour
{
    public CanvasGroup dialogueGroup;
    public TMP_Text dialogueText;
    public GameObject blackScreen;

    public string[] Dialogues;
    public string[] Introductions;
    public float fadeDuration  = 1f;
    public float displayDuration = 10f;
    public int Timer = 10;

    public GameObject player; // Reference to the player GameObject
   [SerializeField] private MonoBehaviour PlayerShoot;
   [SerializeField] private MonoBehaviour movementScript; // Reference to the player's movement script
    [SerializeField] private TimeLeft TimeLeft;
    



   
    void Start()
    {

        TimeLeft = GameObject.Find("Main Menu Manager").GetComponent<TimeLeft>();
        movementScript = player.GetComponent<FirstPersonController>();
       PlayerShoot = player.GetComponent<Player_Shoot>();
        movementScript.enabled = false; // Disable player movement script at the start
        PlayerShoot.enabled = false; // Disable player shooting script at the start
    }

  public IEnumerator PlayDialogue()
    {
        foreach (string dialogue in Dialogues)
        {
            dialogueText.text = dialogue;
           yield return StartCoroutine(FadeInDialogue());
            yield return new WaitForSeconds(displayDuration);
           yield return StartCoroutine(FadeOutDialogue());
            yield return new WaitForSeconds(fadeDuration);
           
        }
       
        yield return StartCoroutine(downTimer());
        yield return StartCoroutine(FadeOutDialogue());
        TimeLeft.StartTimer();

        if (movementScript != null)
        {
            movementScript.enabled = true; // Enable player movement script after dialogue and timer
        }

        if (PlayerShoot != null)
        {
            PlayerShoot.enabled = true; // Enable player shooting script after dialogue and timer
        }

        yield return StartCoroutine(PlayIntroduction());

        

    }


 public  IEnumerator FadeInDialogue()
    {
        dialogueGroup.alpha = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            dialogueGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }
    }

 public  IEnumerator FadeOutDialogue()
    {         float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            dialogueGroup.alpha = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            yield return null;
        }
        dialogueGroup.alpha = 0f; // Ensure it is fully transparent after fading out
    }

 public   IEnumerator downTimer()
    {        
        for (int time = Timer; time >= 0; time--)
        {
            dialogueText.text = "The Exterminator will arrive in " + time + " seconds.";
            yield return StartCoroutine(FadeInDialogue());
            yield return new WaitForSeconds(0.1f); 


        }
       
        blackScreen.SetActive(false);

    }

public IEnumerator PlayIntroduction()
    {

        yield return new WaitForSeconds(1f); // Wait for 1 second before starting introductions
        
        foreach (string introduction in Introductions)
        {
            dialogueText.text = introduction;
            yield return StartCoroutine(FadeInDialogue());
            yield return new WaitForSeconds(displayDuration);
            yield return StartCoroutine(FadeOutDialogue());
            yield return new WaitForSeconds(fadeDuration);
        }
    }
}
