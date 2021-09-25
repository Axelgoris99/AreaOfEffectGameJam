using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    int timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeFlies());
    }
    
    IEnumerator TimeFlies()
    {
        while (true)
        {
            print(timePassed);
            timePassed++;
            yield return new WaitForSeconds(1f);
        }
    }

}
