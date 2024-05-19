using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtnessManager : MonoBehaviour
{
    public int dirtValue;
    public int trashValue;
    public static int dirtCurrent;
    public static int dirtStart = 1;

    public List<GameObject> dirtList;
    private List<GameObject> processedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Find all dirt and trash in the scene
        dirtList = new List<GameObject>();
        dirtList.AddRange(GameObject.FindGameObjectsWithTag("Dirt"));
        dirtList.AddRange(GameObject.FindGameObjectsWithTag("Trash"));
        
        // Calculate start dirt value
        dirtStart = dirtList.Count * dirtValue + dirtList.Count * trashValue;
        
        dirtCurrent = dirtStart;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!processedObjects.Contains(other.gameObject))
        {
            switch (other.gameObject.tag)
            {
                case "Dirt":
                    Destroy(other.gameObject);
                    dirtCurrent -= dirtValue;
                    UpdateCleanliness();
                    Debug.Log("Dirt value subtracted");
                    break;

                case "Trash":
                    Destroy(other.gameObject);
                    dirtCurrent -= trashValue;
                    UpdateCleanliness();
                    Debug.Log("Trash value subtracted");
                    break;
            }
        }
        processedObjects.Add(other.gameObject);
    }

    void UpdateCleanliness()
    {
        float cleanlinessPercentage = (float)dirtCurrent / dirtStart;
        UI.UpdateCleanliness(cleanlinessPercentage);
    }
}
