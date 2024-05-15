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
            StartCoroutine(Sprintbatloss()); 
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

    
    // Coroutine to handle sprint battery loss
    IEnumerator Sprintbatloss()
    {
        float elapsedTime = 0f; // Track elapsed time
        float updateInterval = 1f; // Interval in seconds to update the deduction
        float sprintLossSeconds = (float)GlobalVariables.sprintLoss.TotalSeconds; // Convert sprint loss duration to seconds

        while (PlayerMovement.isSprinting && GlobalVariables.currentTime > 0)
        {
            elapsedTime += Time.deltaTime; // Accumulate time passed

            // Calculate the deduction amount based on sprint loss duration and elapsed time
            float deduction = sprintLossSeconds * elapsedTime * 1.5f; // Speed up deduction

            // Deduct the calculated amount from the current time
            GlobalVariables.currentTime -= deduction * Mathf.Floor(elapsedTime / updateInterval);

            // Reset elapsed time for the next interval using modulus
            elapsedTime %= updateInterval;

            yield return null;
        }
    }

}