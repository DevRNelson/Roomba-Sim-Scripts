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
        dirtList.AddRange(GameObject.FindGameObjectsWithTag("Dirt")); dirtList.AddRange(GameObject.FindGameObjectsWithTag("Trash"));
        //calculate start dirt value
        dirtStart = dirtList.Count * dirtValue + dirtList.Count * trashValue;

        dirtCurrent = dirtStart;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!processedObjects.Contains(other.gameObject))
        {
            if (other.gameObject.CompareTag("Dirt"))
            {
                Destroy(other.gameObject);
                dirtCurrent -= dirtValue;
                UI.UpdateCleanlinessSlider(dirtValue);
                Debug.Log("dirt value subtracted");
            }
            if (other.gameObject.CompareTag("Trash"))
            {
                Destroy(other.gameObject);
                dirtCurrent -= trashValue;
                UI.UpdateCleanlinessSlider(trashValue);
                Debug.Log("trash value subtracted");
            }
        }
        processedObjects.Add(other.gameObject);
    }
}