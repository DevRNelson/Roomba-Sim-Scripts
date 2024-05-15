using System.Collections;
using TMPro;
using UnityEngine;

public class TimerBattery : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject player;

    private float elapsedTime = 0f;  
    
    private float updateInterval = 1f;  
    
    private float sprintMultiplier = 1.5f; 

   
    void Start()
    {
        GlobalVariables.currentTime = GlobalVariables.startTime; // Initialize current time
        StartCoroutine(Timer()); // Start the timer coroutine
    }

   
    void Update()
    {
        if (PlayerMovement.isSprinting)
        {
            StopCoroutine(SprintBatteryLoss()); // Stop the previous coroutine
            StartCoroutine(SprintBatteryLoss()); // Start sprint battery loss coroutine
            timerText.color = Color.red; // Change timer text color to red
        }
        else
        {
            StartCoroutine(SprintBatteryLoss()); // Start sprint battery loss coroutine
            timerText.color = Color.white; // Change timer text color back to white
        }
    }

   
    private IEnumerator Timer()
    {
        while (GlobalVariables.currentTime > 0)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second
            GlobalVariables.currentTime--; // Decrease current time
        }
    }

    // Coroutine to handle sprint battery loss
    private IEnumerator SprintBatteryLoss()
    {
        while (PlayerMovement.isSprinting && GlobalVariables.currentTime > 0)
        {
            elapsedTime += Time.deltaTime; // Accumulate time passed

            // Calculate the deduction amount based on sprint loss duration, elapsed time, and multiplier
            float deduction = (float)GlobalVariables.sprintLoss.TotalSeconds * elapsedTime * sprintMultiplier;

            // Deduct the calculated amount from the current time
            GlobalVariables.currentTime -= deduction * Mathf.Floor(elapsedTime / updateInterval);

            // Reset elapsed time for the next interval using modulus
            elapsedTime %= updateInterval;

            yield return null;  
        }
    }
}
