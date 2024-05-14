using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerBattery : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
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
            StopCoroutine(Timer());
            StartCoroutine(Sprintbatloss());
            timerText.color = Color.red;
            Debug.Log("energy loss");
        }
        else if (PlayerMovement.isSprinting == false)
       {
            StopCoroutine(Sprintbatloss());
            timerText.color = Color.white;
       }
    }

    //Timer coroutine
    public static IEnumerator Timer()
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
        while (PlayerMovement.isSprinting)
        {
            yield return new WaitForSeconds(3);
            GlobalVariables.currentTime -= GlobalVariables.sprintLoss;
            yield return null;
        }
    }
}