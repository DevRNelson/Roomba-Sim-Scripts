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
    string[] dirtColor = new string[] { "red", "yellow", "blue", "orange", "magenta", "green", "purple", "black" };
    private List<GameObject> processedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //find all dirt and trash in scene
        dirtList = new List<GameObject>();
        dirtList.AddRange(GameObject.FindGameObjectsWithTag("Dirt")); 
        dirtList.AddRange(GameObject.FindGameObjectsWithTag("Trash"));
        
        //calculate start dirt value
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
                    UI.UpdateCleanliness(dirtCurrent / dirtStart); // Update cleanliness based on current and maximum values
                    Debug.Log("dirt value subtracted");
                    break;

                case "Trash":
                    Destroy(other.gameObject);
                    dirtCurrent -= trashValue;
                    UI.UpdateCleanliness(dirtCurrent / dirtStart); // Update cleanliness based on current and maximum values
                    Debug.Log("trash value subtracted");
                    break;
            }
        }
        processedObjects.Add(other.gameObject);
    }
}
