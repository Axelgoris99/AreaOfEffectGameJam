using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour
{
    private Collider colliderLetter;
    private void Awake()
    {
        colliderLetter = GetComponent<Collider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(ContainsCube(other.bounds))
            {

            }
    }

    private bool ContainsCube(Bounds cubeBounds)
    {
        Bounds boundsLetter = colliderLetter.bounds;
        if(boundsLetter.max.x > cubeBounds.max.x 
            && boundsLetter.max.y > cubeBounds.max.y
            && boundsLetter.max.z > cubeBounds.max.z
            && boundsLetter.min.x < cubeBounds.min.x
            && boundsLetter.min.y < cubeBounds.min.y
            && boundsLetter.min.z < cubeBounds.min.z
            )
        {
            return true;
        }
        return false;
    }
}
