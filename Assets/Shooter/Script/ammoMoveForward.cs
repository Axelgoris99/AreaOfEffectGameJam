using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoMoveForward : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * speed, 0);    
        if(transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }
}
