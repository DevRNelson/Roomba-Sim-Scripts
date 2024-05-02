using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        SetTextboxText();
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

}
