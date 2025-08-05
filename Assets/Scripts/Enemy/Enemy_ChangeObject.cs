using UnityEngine;

public class Enemy_ChangeObject : MonoBehaviour
{
    public GameObject[] objectsToChange;
    private GameObject currentObject;
    public GameObject visualModel;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeForm()
    {
        if (objectsToChange == null || objectsToChange.Length == 0)
        {
            Debug.LogWarning("No objects to change to!");
            return;
        }

       if (visualModel != null)
            {
            visualModel.SetActive(false); // Disable the visual model if it exists
        }

        int randomIndex = Random.Range(0, objectsToChange.Length);
        GameObject disguise = Instantiate(objectsToChange[randomIndex], transform);


        disguise.transform.localPosition = Vector3.zero; // Reset local position to ensure it aligns with the parent
        disguise.transform.localRotation = Quaternion.identity; // Reset local rotation to ensure it aligns with the parent
        disguise.transform.localScale = Vector3.one; // Reset local scale to ensure it matches the parent

        currentObject = disguise;
    }
}
