using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Hiding_Script assignedSpot;
    private bool spotAssigned = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Try to find an available hiding spot
        AssignHidingSpot();
    }

    void AssignHidingSpot()
    {
        GameObject[] hidingObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in hidingObjects)
        {
            Hiding_Script spot = obj.GetComponent<Hiding_Script>();
            if (spot != null && !spot.IsClaimed())
            {
                if (spot.TryClaim())
                {
                    assignedSpot = spot;
                    spotAssigned = true;
                    agent.SetDestination(spot.transform.position);
                    break;
                }
            }
        }

        if (!spotAssigned)
        {
            Debug.LogWarning($"{gameObject.name} could not find a free hiding spot!");
        }
    }
}
