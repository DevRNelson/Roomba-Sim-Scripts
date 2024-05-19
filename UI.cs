using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    public Image cleanlinessBar;
    public Image BatteryBar;

    void Start()
    {
        SetTextboxText();
        // Set initial cleanliness to empty
        UpdateCleanliness(0f);
        
        // Set initial cleanliness bar fill amount to 0
        cleanlinessBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        SetTextboxText();
    }

    public void SetTextboxText()
    {
        float displayTime = Mathf.Max(0, GlobalVariables.currentTime);
        int minutes = Mathf.FloorToInt(displayTime / 60);
        int seconds = Mathf.FloorToInt(displayTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        UpdateTimerText(timeString);

        // BatteryBar Calculate fill amount based on time
        float fillAmount = displayTime / GlobalVariables.maxTime;
        BatteryBar.fillAmount = fillAmount;
    }

    private void UpdateTimerText(string timeString)
    {
        timerText.text = timeString;
    }

    public static void UpdateCleanliness(float cleanlinessPercentage)
    {
        UI uiInstance = FindObjectOfType<UI>();
        if (uiInstance != null)
        {
            // Set cleanliness bar fill amount directly without reversing
            uiInstance.cleanlinessBar.fillAmount = 1f - cleanlinessPercentage;
        }
    }

    void SetInitialCleanliness()
    {
        DirtnessManager dirtnessManager = FindObjectOfType<DirtnessManager>();
        if (dirtnessManager != null)
        {
            // Set initial cleanliness to empty
            UpdateCleanliness(0f);
        }
    }
}
