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
        cleanlinessBar.fillAmount = 1f; // Assuming initial cleanliness is full
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
            uiInstance.cleanlinessBar.fillAmount = cleanlinessPercentage;
        }
    }

    void SetInitialCleanliness()
    {
        DirtnessManager dirtnessManager = FindObjectOfType<DirtnessManager>();
        if (dirtnessManager != null)
        {
            UpdateCleanliness(1f); // Assuming initial cleanliness is full
        }
    }
}
