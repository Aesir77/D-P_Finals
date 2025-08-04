using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue_and_Timer : MonoBehaviour
{
    public CanvasGroup dialogueGroup;
    public TMP_Text dialogueText;
    public GameObject blackScreen;

    public string[] Dialogues; 
    public float fadeDuration  = 1f;
    public float displayDuration = 10f;
    public int Timer = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Dialogues.Length > 0)
        {
            StartCoroutine(PlayDialogue());
        }
    }

   IEnumerator PlayDialogue()
    {
        foreach (string dialogue in Dialogues)
        {
            dialogueText.text = dialogue;
           yield return StartCoroutine(FadeInDialogue());
            yield return new WaitForSeconds(displayDuration);
           yield return StartCoroutine(FadeOutDialogue());
            yield return new WaitForSeconds(fadeDuration);
        }

        yield return StartCoroutine(FadeInDialogue());
        yield return StartCoroutine(downTimer());
        yield return StartCoroutine(FadeOutDialogue());

        
         
    }


   IEnumerator FadeInDialogue()
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

    IEnumerator FadeOutDialogue()
    {         float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            dialogueGroup.alpha = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            yield return null;
        }
        dialogueGroup.alpha = 0f; // Ensure it is fully transparent after fading out
    }

    IEnumerator downTimer()
    {        
        for (int time = Timer; time >= 0; time--)
        {
            dialogueText.text = "The Exterminator will arrive in " + time + " seconds.";
            yield return new WaitForSeconds(1f);
        }
       
        blackScreen.SetActive(false);

    }

}
