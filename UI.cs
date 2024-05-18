using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    public Image cleanlinessBar;

    void Start()
    {
        SetTextboxText();
        // Set the initial cleanliness value based on the maximum calculated value from DirtnessManager
        cleanlinessBar.fillAmount = 1f; // Assuming initial cleanliness is full
    }

    // Update is called once per frame
    void Update()
    {
        SetTextboxText();
    }

    public void SetTextboxText()
    {
        float displayTime = Mathf.Max(0, GlobalVariables.currentTime); // Ensure currentTime never goes below 0
        int minutes = Mathf.FloorToInt(displayTime / 60);
        int seconds = Mathf.FloorToInt(displayTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds); // Display the time in the format Minutes:Seconds
        UpdateTimerText(timeString);
    }

    private void UpdateTimerText(string timeString)
    {
        timerText.text = timeString; // Update the timer text with the formatted time string
    }
  
}
