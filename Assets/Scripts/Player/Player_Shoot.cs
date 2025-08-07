using UnityEngine;


public class Player_Shoot : MonoBehaviour
{
    [SerializeField] private GameObject netPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            ShootNet();
        }
    }

    void ShootNet()
    {
        GameObject net = Instantiate(netPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = net.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = shootPoint.forward * shootForce;
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the net prefab.");
        }   
    }
}
