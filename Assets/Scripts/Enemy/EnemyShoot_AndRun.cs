using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot_AndRun : MonoBehaviour
{
    public float detectionRange = 10f, shootDelay = 1.5f; 
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private Transform player; 
    private NavMeshAgent agent; 
    private bool hasShot = false;
    private bool isFleeing = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || isFleeing) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && !hasShot)
        {
            if (!hasShot)
            {
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                StartCoroutine(ShootAtPlayer());

            }
        }

    }

    IEnumerator ShootAtPlayer()
    {
        hasShot = true;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (player.position - bulletSpawnPoint.position).normalized;
            rb.AddForce(direction * 10f, ForceMode.Impulse); // Adjust force as needed
        }
        yield return new WaitForSeconds(shootDelay);

        Vector3 fleeDirection = (transform.position - player.position).normalized;
        Vector3 fleePosition = transform.position + fleeDirection * detectionRange;
        agent.SetDestination(fleePosition);

        hasShot = false;
    }
}
