using System;
using System.Collections;
using System.Collections.Generic;
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
        timerText.text = GlobalVariables.currentTime.ToString();
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
