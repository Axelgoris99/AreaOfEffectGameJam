using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulation : MonoBehaviour
{
    private Material material;
    private Color originalColor;
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
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0.25f;
            transform.position = newPosition;
        }
    }

    private void OnMouseExit()
    {
        material.color = originalColor;
    }
}
