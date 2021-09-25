using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;
public class moveAI : MonoBehaviour
{
    AIMContext aimContext;
    // Start is called before the first frame update
    void Start()
    {
        aimContext = GetComponent<AIMContext>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(aimContext.DecidedDirection);
    }
}
