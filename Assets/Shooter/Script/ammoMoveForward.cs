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

        //if(transform.position.y > 15)
        //{
        //    Destroy(gameObject);
        //}
        //if (transform.position.y < -15)
        //{
        //    Destroy(gameObject);
        //}
        //if (transform.position.x > 15)
        //{
        //    Destroy(gameObject);
        //}
        //if (transform.position.x < -15)
        //{
        //    Destroy(gameObject);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Destroy(gameObject);
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Signs form = other.GetComponent<Signs>();
            form.SetHealth(form.Health - 1);
            Destroy(gameObject);
        }
    }
}
