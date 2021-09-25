using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    [SerializeField]
    private spawnEnemy spawn;

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
            timePassed++;
            if(timePassed % 10 == 0)
            {
                spawn.TimeForSpawn = spawn.TimeForSpawn - 0.1f;
                spawn.NbMaxOfEnemy = spawn.NbMaxOfEnemy+1;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
