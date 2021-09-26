using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercentage : MonoBehaviour
{
    [SerializeField]
    private ScreenshotCamera cameraScript;
    private Slider m_slider;

    // Start is called before the first frame update
    void Start()
    {
        m_slider.value = cameraScript.GetPercentage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSliderValue()
    {
        m_slider.value = cameraScript.GetPercentage();
    }
}
