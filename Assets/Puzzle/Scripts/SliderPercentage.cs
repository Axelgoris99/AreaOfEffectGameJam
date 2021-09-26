using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercentage : MonoBehaviour
{
    [SerializeField]
    private ScreenshotCamera cameraScript;
    private Slider m_slider;
    private void Awake()
    {
        m_slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_slider.value = 0f;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSliderValue(float givenValue)
    {
        m_slider.value = givenValue;
    }
}
