using UnityEngine;

public class Net_Shoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rat"))
        {
            StartCoroutine(HandleRatCaught(other.gameObject));
        }
    }

    private System.Collections.IEnumerator HandleRatCaught(GameObject rat)
    {
        rat.GetComponent<Rigidbody>().isKinematic = true; // Stop the rat's physics interactions
        yield return new WaitForSeconds(0.25f); // Wait for 2 seconds before destroying the rat
        Destroy(rat); // Destroy the rat GameObject
    }
}
