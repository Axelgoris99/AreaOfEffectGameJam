using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotCamera : MonoBehaviour
{
    private Camera camera;
    public bool takeScreenshot = false;
    public RenderTexture emptyLetterScreen;
    public RenderTexture actualLetterScreen;
    private Color[] actualPixelsTable;
    private int fullLetterPixels;
    private int fullBackPixels;
    private float percentageCovered = 0;
    private float percentageOut = 0;
    public Texture2D textureScreen2;
    [SerializeField]
    private SliderPercentage sliderCompletionScript;
    [SerializeField]
    private SliderPercentage sliderOverrunScript;
    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("InitializeWhite");
    }

    // Update is called once per frame
    void Update()
    {
        if (takeScreenshot)
        {
            //take screenshot :
            actualLetterScreen = new RenderTexture(camera.scaledPixelWidth, camera.scaledPixelHeight, (int)camera.depth);
            RenderTexture.active = actualLetterScreen;
            camera.targetTexture = actualLetterScreen;
            camera.Render();            
        }    
    }

    private void OnPostRender()
    {
        if(takeScreenshot)
        {            
            takeScreenshot = false;
            StartCoroutine("ProcessPhoto");
        }
                
    }
    IEnumerator ProcessPhoto()
    {
        textureScreen2 = new Texture2D(actualLetterScreen.width, actualLetterScreen.height);
        Rect rectReadPicture = new Rect(0, 0, actualLetterScreen.width, actualLetterScreen.height);
        RenderTexture.active = actualLetterScreen;
        yield return new WaitForSeconds(1f);
        textureScreen2.ReadPixels(rectReadPicture, 0, 0);
        textureScreen2.Apply();

        actualPixelsTable = textureScreen2.GetPixels(0, 0, actualLetterScreen.width, actualLetterScreen.height);

        int actualLetterPixels = 0;
        int actualBackPixels = 0;
        foreach (Color col in actualPixelsTable)
        {
            if (col.r > 0.9 && col.g > 0.9 && col.b > 0.9)
            {
                actualLetterPixels += 1;
            }
            else if (col.r < 0.01 && col.g < 0.01 && col.b < (65f / 256f + 0.05f) && col.b > (65f / 256f - 0.05f))
            {
                actualBackPixels += 1;
            }
        }
        percentageCovered = 1f - (float)actualLetterPixels / (float)fullLetterPixels;
        percentageOut = 1f - (float)actualBackPixels / (float)fullBackPixels;

        sliderCompletionScript.UpdateSliderValue(percentageCovered);
        sliderOverrunScript.UpdateSliderValue(percentageOut);

        Debug.Log("actual white pixels = " + actualLetterPixels);
        Debug.Log("back pixels "+fullBackPixels);
        yield return null;
    }

    IEnumerator InitializeWhite()
    {
        yield return new WaitForEndOfFrame();
        emptyLetterScreen = new RenderTexture(camera.scaledPixelWidth, camera.scaledPixelHeight, (int)camera.depth);
        emptyLetterScreen.Create();
        camera.targetTexture = emptyLetterScreen;
        camera.Render();

        Texture2D textureScreen = new Texture2D(emptyLetterScreen.width, emptyLetterScreen.height);
        Rect rectReadPicture = new Rect(0, 0, emptyLetterScreen.width, emptyLetterScreen.height);
        RenderTexture.active = emptyLetterScreen;

        yield return new WaitForSeconds(0.5f);
        textureScreen.ReadPixels(rectReadPicture, 0, 0);
        textureScreen.Apply();

        actualPixelsTable = textureScreen.GetPixels(0, 0, emptyLetterScreen.width, emptyLetterScreen.height);

        fullLetterPixels = 0;
        fullBackPixels = 0;
        foreach (Color col in actualPixelsTable)
        {
            if (col.r > 0.9 && col.g > 0.9 && col.b > 0.9)
            {
                fullLetterPixels += 1;
            }
            else if (col.r < 0.01 && col.g < 0.01 && col.b < (65f/256f +0.05f) && col.b > (65f / 256f - 0.05f))
            {
                fullBackPixels += 1;
            }
        }
        Debug.Log("total white pixels letter = " + fullLetterPixels);
        Debug.Log("total back blue pixels " + fullBackPixels);
        //RenderTexture.active = null;
        camera.enabled = false;
        RenderTexture.active = null;
        yield return null;
    }

    public float GetPercentage()
    {
        return percentageCovered;
    }    
}
