using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    private Material material;
    private Color originalColor;
    private bool isClicked = false;
    public Camera mainCamera;
    [SerializeField]
    public static bool AnObjectIsHold;
    private bool isIntersecting = false;
    [SerializeField]
    private ScreenshotCamera scriptCalculWhite;
    public float offset = 0f;
    
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;

        scriptCalculWhite = GameObject.Find("Camera").GetComponent<ScreenshotCamera>();  

        if(mainCamera==null)
        {
            mainCamera = Camera.main;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //quand la pièce est générée depuis l'inventaire, elle est cliquée
        AnObjectIsHold = true;
        isClicked = true;
        StartCoroutine("FollowMouse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        material.color = Color.yellow;
    }

    private void OnMouseOver()
    {        
        //Debug.Log(Input.mousePosition);
        //Debug.Log("world" + mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4)));
        if(Input.GetMouseButtonDown(0))
        {
            if(!AnObjectIsHold)
            {
                StartCoroutine("FollowMouse");
                isClicked = true;
                AnObjectIsHold = true;
            }
            else if(isClicked && !isIntersecting)
            {
                StopCoroutine("FollowMouse");
                isClicked = false;
                AnObjectIsHold = false;
                scriptCalculWhite.takeScreenshot = true; //à remplacer par un accesseur plutôt
            }
        }
        if(Input.GetKeyDown(KeyCode.R) && isClicked)
        {
            transform.Rotate(Vector3.up, 45f);
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
            //transform.position = newPosition;
            transform.position = new Vector3(newPosition.x, 0.25f + offset, newPosition.z); ;
            yield return null;
        }        
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    List<ContactPoint> listPoints = new List<ContactPoint>();
    //    float interdistance = 0f;
    //    collision.GetContacts(listPoints);
    //    Debug.Log("nbre points collision "+listPoints.Count);
    //    foreach(ContactPoint contact in listPoints)
    //    {
    //        Debug.Log(contact.separation);
    //        if (contact.separation < interdistance)
    //        {
    //            interdistance = contact.separation;
    //        }
    //    }
    //    if(-interdistance > limitPenetration)
    //    {
    //        material.color = Color.red;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (!(other.tag=="Letter") && other.bounds.Intersects(this.GetComponent<Collider>().bounds))
        {
            material.color = Color.red;
            isIntersecting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!(other.tag == "Letter"))
        {
            isIntersecting = false;
            if (isClicked)
            {
                material.color = Color.yellow;
            }
            else
            {
                material.color = originalColor;
            }
        }
    }
}
