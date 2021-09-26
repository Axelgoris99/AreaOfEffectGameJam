using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
public class SliderPercentage : MonoBehaviour
{
    [SerializeField]
    private ScreenshotCamera cameraScriptCalcul;
    private Slider m_slider;

    public TextMeshProUGUI score;
    public GameObject victoire;

    public time timePassed;
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
        if(m_slider.value > 0.8)
        {
            victoire.SetActive(true);
            score.text = ((float)4/(float)timePassed.timePassed).ToString();
            StartCoroutine(MainMenuBack());
        }
    }

    public void UpdateSliderValue(float givenValue)
    {
        m_slider.value = givenValue;
    }
    
    IEnumerator MainMenuBack()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("MainMenu");
    }
   
}
