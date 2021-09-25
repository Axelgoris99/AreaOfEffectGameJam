using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    private Material material;
    private Color originalColor;
    private bool isClicked = false;
    public Camera mainCamera;
    private static bool anObjectIsHold = false;
    
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;

        if(mainCamera==null)
        {
            mainCamera = Camera.main;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //quand la pièce est générée depuis l'inventaire, elle est cliquée
        anObjectIsHold = true;
        isClicked = true;
        StartCoroutine("FollowMouse");
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
            if(!anObjectIsHold)
            {
                StartCoroutine("FollowMouse");
                isClicked = true;
                anObjectIsHold = true;
            }
            else if(isClicked)
            {
                StopCoroutine("FollowMouse");
                isClicked = false;
                anObjectIsHold = false;
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
            yield return null;
        }        
    }
}
