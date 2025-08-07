using UnityEngine;

public class Enemy_ChangeObject : MonoBehaviour
{
    public GameObject[] objectsToChange;
    private GameObject currentObject;
    public GameObject visualModel;


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


        disguise.transform.localPosition = new Vector3(0, -0.5f, 0); // Lower the y to make the disguise sit on the ground
        disguise.transform.localRotation = new Quaternion(0, 0, 0, 1); // Reset rotation to identity
        disguise.transform.localScale = Vector3.one; // Reset local scale to ensure it matches the parent

        currentObject = disguise;
    }
}
