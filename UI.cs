using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    public Image cleanlinessBar;

    // Start is called before the first frame update
    void Start()
    {
        SetTextboxText();
        //_cleanSlider.maxValue = DirtnessManager.dirtStart;
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


    public static void SetCleanliness()
    {
        //cleanSlider.value = DirtnessManager.dirtCurrent;
    }

    public static void UpdateCleanlinessSlider(int value)
    {
        // _cleanSlider.value += value;
    }
}
