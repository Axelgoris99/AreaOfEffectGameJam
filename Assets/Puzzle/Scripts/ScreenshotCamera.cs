using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotCamera : MonoBehaviour
{
    private Camera camera;
    public bool takeScreenshot = false;
    private Texture2D emptyLetterScreen;
    private Texture2D actualLetterScreen;
    private Color[] actualPixelsTable;
    private int fullLetterPixels;
    private float percentageCovered = 0;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        emptyLetterScreen = new Texture2D(Screen.width, Screen.height);
        emptyLetterScreen.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        emptyLetterScreen.Apply();

        actualPixelsTable = emptyLetterScreen.GetPixels(0, 0, emptyLetterScreen.width, emptyLetterScreen.height);
        fullLetterPixels = 0;
        foreach(Color col in actualPixelsTable)
        {
            if(col.r>0.9 && col.g>0.9 && col.b>0.9)
            {
                fullLetterPixels += 1;
            }
        }
        camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPostRender()
    {
        if(takeScreenshot)
        {
            camera.enabled = true;
            takeScreenshot = false;
            //take screenshot :
            actualLetterScreen = new Texture2D(Screen.width, Screen.height);
            actualLetterScreen.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            actualLetterScreen.Apply();

            //get and count pixels :
            actualPixelsTable = actualLetterScreen.GetPixels(0, 0, actualLetterScreen.width, actualLetterScreen.height);
            int actualLetterPixels = 0;
            foreach (Color col in actualPixelsTable)
            {
                if (col.r > 0.9 && col.g > 0.9 && col.b > 0.9)
                {
                    actualLetterPixels += 1;
                }
            }
            percentageCovered = 1f - actualLetterPixels / fullLetterPixels;
            Debug.Log(percentageCovered);
            camera.enabled = false;
        }
    }
}
