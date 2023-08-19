using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    public WebViewController WebViewController;
    public Slider Slider;
    public TextMeshProUGUI Text_resolution;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public void ClickButton()
    {
        Debug.Log("Debug08");
    }

    public void change_resolution()
    {
        WebViewController.CanvasWebViewPrefab.Resolution = Slider.value;
        Text_resolution.text = (Math.Floor(Slider.value * 100) / 100).ToString();
        Debug.Log("Debug10-3 " + Slider.value);
    }
}
