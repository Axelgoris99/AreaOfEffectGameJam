using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpBG : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + player.up * -speed * Time.deltaTime;
        if(transform.position.x > 60.75f)
        {
            transform.position = new Vector3(-20.25f, transform.position.y, 0);
        }
        if (transform.position.x < -20.25f)
        {
            transform.position = new Vector3(60.75f, transform.position.y, 0);
        }

        if (transform.position.y < -40.5f)
        {
            transform.position = new Vector3(transform.position.x, 13.5f, 0);
        }
        if (transform.position.y > 13.5f)
        {
            transform.position = new Vector3(transform.position.x, -40.5f, 0);
        }
    }
}
