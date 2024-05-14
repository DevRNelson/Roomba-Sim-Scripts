using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    public float fadeSpeed, fadeAmount;
    float originalOpacity;

    Renderer renderer;
    Material Mat;
    public bool Defade = false;

    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<Renderer>().material; // Changed from GetComponent<Material>() to GetComponent<Renderer>().material
        originalOpacity = Mat.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (Defade)
            FadeNow();
        else
            ResetFade();
    }

    void FadeNow()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed));
        Mat.color = smoothColor;
    }

    void ResetFade()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed));
        Mat.color = smoothColor;
    }
}
