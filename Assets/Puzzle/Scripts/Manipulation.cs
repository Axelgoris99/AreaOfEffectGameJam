using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    private Material material;
    private Color originalColor;
    private bool isClicked = false;
    public Camera mainCamera;
    
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        material.color = Color.yellow;
        //Debug.Log(Input.mousePosition);
        //Debug.Log("world" + mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4)));
        if(Input.GetMouseButtonDown(0))
        {
            if(!isClicked)
            {
                StartCoroutine("FollowMouse");
                isClicked = true;
            }
            else
            {
                StopCoroutine("FollowMouse");
                isClicked = false;
            }
        }
    }

    private void OnMouseExit()
    {
        if(!isClicked)
        {
            material.color = originalColor;     
        }   
    }

    IEnumerator FollowMouse()
    {
        while(true)     //just to try
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (mainCamera.transform.position.y - transform.position.y)));
            transform.position = newPosition;
            Debug.Log(newPosition);
            yield return null;
        }        
    }
}
