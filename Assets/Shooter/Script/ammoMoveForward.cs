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
        transform.position += transform.up * Time.deltaTime * speed;

    }
}
