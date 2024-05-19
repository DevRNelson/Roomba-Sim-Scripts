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
        switch (PlayerMovement.isSprinting)
        {
            case true:
                StartCoroutine(SprintBatteryLoss()); // Start sprint battery loss coroutine
                timerText.color = Color.red; // Change timer text color to red
                break;
            case false:
                StopCoroutine(SprintBatteryLoss()); // Stop sprint battery loss coroutine
                timerText.color = Color.white; // Change timer text color back to white
                break;
        }
    }

    public IEnumerator Timer() // Fixed the return type to IEnumerator
    {
        while (GlobalVariables.currentTime > 0)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second
            GlobalVariables.currentTime--; // Decrease current time
        }
    }

    private IEnumerator SprintBatteryLoss()
    {
        float deductionPerSecond = 0.004f; // Constant deduction rate of 0.004f
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
