using UnityEngine;



public class Player_Shoot : MonoBehaviour
{
    [SerializeField] private GameObject netPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float netLifetime = 2f; 
    [SerializeField] private Vector3 lastPos, simulatedVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        simulatedVelocity = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;
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
         Camera cam = Camera.main;
          Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Ray ray = cam.ScreenPointToRay(screenCenter);

            Vector3 shootDirection = ray.direction.normalized;
                
           rb.linearVelocity = shootDirection * shootForce + simulatedVelocity; 
            rb.angularVelocity = Vector3.zero; 

            Destroy(net, netLifetime); // Destroy the net after a certain time
        }
       

        if (Time.deltaTime > 0)
        {
            simulatedVelocity = (transform.position - lastPos) / Time.deltaTime; // Update simulated velocity
        }
        else
        {
            simulatedVelocity = Vector3.zero; // Reset if delta time is zero to avoid division by zero
        }
    }
}
