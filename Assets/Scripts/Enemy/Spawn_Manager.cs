using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    public GameObject RatPrefab;
    public int no_ofRats = 10;
    public float spawnRange = 5f;

    public void SpawnRats()
    {
        for (int i = 0; i < no_ofRats; i++)
        {
            Vector3 spawnPosition = SpawnPoint.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
            Instantiate(RatPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void ClearRats() //will only be used when returning to the main menu
    {
               GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat");
        foreach (GameObject rat in rats)
        {
            Destroy(rat);
        }
    }
}
