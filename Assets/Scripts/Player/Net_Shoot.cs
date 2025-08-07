using System.Collections;
using UnityEngine;


public class Net_Shoot : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rat"))
        {
            StartCoroutine(HandleRatCaught(other.gameObject));
        }
    }

   private System.Collections.IEnumerator HandleRatCaught(GameObject rat)
    {
       Enemy_AI enemyAi = rat.GetComponent<Enemy_AI>();
        if (enemyAi != null)
        {
            enemyAi.enabled = false; // Disable the AI script to stop movement
        }
       

        yield return new WaitForSeconds(0.25f); // Wait for 1 second before destroying the rat
        Destroy(rat); // Destroy the rat GameObject
    }
}
