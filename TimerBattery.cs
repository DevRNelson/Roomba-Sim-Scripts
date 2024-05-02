using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBattery : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        float startTime = GlobalVariables.startTime;
        GlobalVariables.currentTime = startTime;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerMovement.isSprinting == true)
        {
            Sprintbatloss();
            Debug.Log("energy loss");
        }

    }

    //Timer coroutine
    IEnumerator Timer()
    {
        while (GlobalVariables.currentTime > 0)
        {
            yield return new WaitForSeconds(1);
            GlobalVariables.currentTime--;
        }
    }
    
    // Method to handle sprint battery loss
    IEnumerator Sprintbatloss()
    {
        yield return new WaitForSeconds(6);
        GlobalVariables.currentTime -= GlobalVariables.sprintLoss;
    }
}
