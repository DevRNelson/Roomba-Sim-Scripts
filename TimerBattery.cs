using System.Collections;
using TMPro;
using UnityEngine;

public class TimerBattery : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject player;
  
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

    private IEnumerator SprintBatteryLoss()
    {
        float deductionPerSecond = 0.001f; // Constant deduction rate of 0.001f (I believe the higher values are a bit too fast with how fast it drains, i feel this  and similar ranges to it is more reasonable for a level )
        float elapsedTime = 0f;

        while (PlayerMovement.isSprinting && GlobalVariables.currentTime > 0)
        {
            elapsedTime += Time.deltaTime;

            float timeToDeduct = deductionPerSecond * Time.deltaTime;

            GlobalVariables.currentTime -= timeToDeduct;

            yield return null;
        }
    }

}