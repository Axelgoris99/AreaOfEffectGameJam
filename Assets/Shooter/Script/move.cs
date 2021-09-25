using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;
    // Update is called once per frame
    void Update()
    {
        Vector3 translation = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speedX, Input.GetAxis("Vertical") * Time.deltaTime * speedY, 0);
        transform.Translate(translation);
        
        if(transform.position.x < -13.4)
        {
            transform.position = new Vector3(13.4f, transform.position.y, 0);
        }
        if (transform.position.x > 13.4)
        {
            transform.position = new Vector3(-13.4f, transform.position.y, 0);
        }
        if(transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
        if (transform.position.y > 6.92)
        {
            transform.position = new Vector3(transform.position.x, 6.92f, 0);
        }
    }
}
