using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    public Transform player; // Assign in Inspector or find by tag
    public float detectionRange = 20f; // Distance to start hiding
    public float hideCheckInterval = 1.5f; // Delay between hide attempts

    private NavMeshAgent agent;
    private float hideTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }


    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            hideTimer += Time.deltaTime;

            if (hideTimer >= hideCheckInterval)
            {
                hideTimer = 30f;
                FindAndGoToHidingSpot();
            }
        }
    }

    void FindAndGoToHidingSpot()
    {
        GameObject[] hidingSpots = GameObject.FindGameObjectsWithTag("HidingSpot");
        if (hidingSpots.Length == 0) return;

        GameObject bestSpot = null;
        float bestScore = float.MinValue;

        foreach (GameObject spot in hidingSpots)
        {
            Vector3 directionToPlayer = (player.position - spot.transform.position).normalized;
            float distanceFromPlayer = Vector3.Distance(player.position, spot.transform.position);
            float dot = Vector3.Dot(spot.transform.forward, directionToPlayer); // How well it's hidden from player
            float score = distanceFromPlayer + dot * 5f; // Customize weight

            // Optionally check if reachable
            if (NavMesh.SamplePosition(spot.transform.position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                if (score > bestScore)
                {
                    bestScore = score;
                    bestSpot = spot;
                }
            }
        }

        if (bestSpot != null)
        {
            agent.SetDestination(bestSpot.transform.position);
        }
    }
}
