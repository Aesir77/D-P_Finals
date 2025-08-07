using UnityEngine;



public class Player_Shoot : MonoBehaviour
{
    [SerializeField] private GameObject netPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 10f, nextshoot = 0.25f;
    [SerializeField] private float netLifetime = 2f, shootCooldown = 1.25f; 
    [SerializeField] private Vector3 lastPos, simulatedVelocity;
   
  
    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {

        simulatedVelocity = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;
        if (Input.GetMouseButtonDown(0) && Time.time >= nextshoot) // Left mouse button
        {
            ShootNet();
            nextshoot = Time.time + shootCooldown;

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
            Vector3 FinalVelocity = shootDirection * shootForce + simulatedVelocity;
            if (isValid(FinalVelocity))
            {
                rb.linearVelocity = FinalVelocity; 
            }
            rb.angularVelocity = Vector3.zero;

                Destroy(net, netLifetime); // Destroy the net after a certain time

           
        }
       

        if (Time.deltaTime > Mathf.Epsilon)
        {
            simulatedVelocity = (transform.position - lastPos) / Time.deltaTime; // Update simulated velocity
        }
        else
        {
            simulatedVelocity = Vector3.zero; // Reset if delta time is zero to avoid division by zero
        }
    }

    bool isValid(Vector3 valid)
    {
        return !(float.IsNaN(valid.x) || float.IsNaN(valid.y) || float.IsNaN(valid.z) ||
                 float.IsInfinity(valid.x) || float.IsInfinity(valid.y) || float.IsInfinity(valid.z));
    }
}
