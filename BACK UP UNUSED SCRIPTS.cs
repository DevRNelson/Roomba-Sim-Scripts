using UnityEngine;
using UnityEngine.UI;
//THIS UI SCRIPT EDIT TIES THE UI OF A BAR WITH A FILL AMOUNT TO THE TIME LEFT FOR E.G  A BATTERY BAR UI DISPLAY

//public static float maxTime = 60.0f; //1 minute max time   GLOBAL VARIABLE FOR THIS CODE'S MAX TIME
public class TimerScript : MonoBehaviour
{
    public Image cleanlinessBar;
    public Text timerText;

    public void SetTextboxText()
    {
        float displayTime = Mathf.Max(0, GlobalVariables.currentTime); // Ensure currentTime never goes below 0
        int minutes = Mathf.FloorToInt(displayTime / 60);
        int seconds = Mathf.FloorToInt(displayTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds); // Display the time in the format Minutes:Seconds
        UpdateTimerText(timeString);

        // Calculate fill amount based on time
        float fillAmount = displayTime / GlobalVariables.maxTime;
        cleanlinessBar.fillAmount = fillAmount;
    }

    private void UpdateTimerText(string timeString)
    {
        timerText.text = timeString; // Update the timer text with the formatted time string
    }
}
