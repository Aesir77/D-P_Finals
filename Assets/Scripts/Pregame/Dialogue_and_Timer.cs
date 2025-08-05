using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;

public class Dialogue_and_Timer : MonoBehaviour
{
    public CanvasGroup dialogueGroup;
    public TMP_Text dialogueText;
    public GameObject blackScreen;

    public string[] Dialogues; 
    public float fadeDuration  = 1f;
    public float displayDuration = 10f;
    public int Timer = 10;

    public GameObject player; // Reference to the player GameObject
    private MonoBehaviour movementScript; // Reference to the player's movement script


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       movementScript = player.GetComponent<MonoBehaviour>();
       movementScript.enabled = false; // Disable player movement script at the start
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

        if (movementScript != null)
        {
            movementScript.enabled = true; // Enable player movement script after dialogue and timer
        }


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
            


        }
       
        blackScreen.SetActive(false);

    }

}
