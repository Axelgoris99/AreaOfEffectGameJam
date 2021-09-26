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
    private float percentageCovered = 0;
    public Texture2D textureScreen2;
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
            actualLetterScreen = new RenderTexture(Screen.width, Screen.height, (int)camera.depth);
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
            //actualLetterScreen = new Texture2D(Screen.width, Screen.height);
            ////actualLetterScreen.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            ////actualLetterScreen.Apply();
            //camera.targetTexture = actualLetterScreen;

            ////get and count pixels :
            //actualPixelsTable = actualLetterScreen.GetPixels(0, 0, actualLetterScreen.width, actualLetterScreen.height);

            //textureScreen2 = new Texture2D(actualLetterScreen.width, actualLetterScreen.height);
            //Rect rectReadPicture = new Rect(0, 0, actualLetterScreen.width, actualLetterScreen.height);
            //RenderTexture.active = actualLetterScreen;            
            //textureScreen2.ReadPixels(rectReadPicture, 0, 0);
            //textureScreen2.Apply();

            //actualPixelsTable = textureScreen2.GetPixels(0, 0, actualLetterScreen.width, actualLetterScreen.height);

            //int actualLetterPixels = 0;
            //foreach (Color col in actualPixelsTable)
            //{
            //    if (col.r > 0.9 && col.g > 0.9 && col.b > 0.9)
            //    {
            //        actualLetterPixels += 1;
            //    }
            //}
            //percentageCovered = 1f - actualLetterPixels / fullLetterPixels;
            //Debug.Log("actual white pixels = "+actualLetterPixels);
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
        foreach (Color col in actualPixelsTable)
        {
            if (col.r > 0.9 && col.g > 0.9 && col.b > 0.9)
            {
                actualLetterPixels += 1;
            }
        }
        percentageCovered = 1f - (float)actualLetterPixels / (float)fullLetterPixels;
        Debug.Log("actual white pixels = " + actualLetterPixels);
        Debug.Log("percentage covered " + percentageCovered);
        yield return null;
    }

    IEnumerator InitializeWhite()
    {
        yield return new WaitForEndOfFrame();
        emptyLetterScreen = new RenderTexture(Screen.width, Screen.height, (int)camera.depth);
        camera.targetTexture = emptyLetterScreen;
        camera.Render();
        //emptyLetterScreen = new Texture2D(Screen.width, Screen.height);
        //emptyLetterScreen.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //emptyLetterScreen.Apply();

        Texture2D textureScreen = new Texture2D(emptyLetterScreen.width, emptyLetterScreen.height);
        Rect rectReadPicture = new Rect(0, 0, emptyLetterScreen.width, emptyLetterScreen.height);
        RenderTexture.active = emptyLetterScreen;

        yield return new WaitForSeconds(0.5f);
        textureScreen.ReadPixels(rectReadPicture, 0, 0);
        textureScreen.Apply();

        actualPixelsTable = textureScreen.GetPixels(0, 0, emptyLetterScreen.width, emptyLetterScreen.height);

        fullLetterPixels = 0;
        foreach (Color col in actualPixelsTable)
        {
            if (col.r > 0.9 && col.g > 0.9 && col.b > 0.9)
            {
                fullLetterPixels += 1;
            }
        }
        Debug.Log("total white pixels letter = " + fullLetterPixels);
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
