using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField]
    Signs[] formToSpawn;
    [SerializeField]
    Signs[] UniqueFormToSpawn;
    List<Vector3> possibleSpawnPoint = new List<Vector3>();
    List<int> probability = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        int count = formToSpawn.Length;
        
        for(int i = 0; i<count; i++)
        {
            for(int j = 0; j < formToSpawn[i].Probability; j++)
            {
                probability.Add(i);
            }
        }

        for(int i = 0; i < 100; i++)
        {
            Vector3 spawnLeft = new Vector3(Random.Range(-15f, -14f), Random.Range(1f, 10f), 0);
            Vector3 spawnRight = new Vector3(Random.Range(14f, 15f), Random.Range(1f, 10f), 0);
            Vector3 spawnUp = new Vector3(Random.Range(-15f, 15f), Random.Range(10f, 11f), 0);
            possibleSpawnPoint.Add(spawnLeft);
            possibleSpawnPoint.Add(spawnRight);
            possibleSpawnPoint.Add(spawnUp);
        }

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int count = possibleSpawnPoint.Count;
        while (true)
        {
            Vector3 spawnPoint = possibleSpawnPoint[Random.Range(0, count)];
            GameObject toSpawn = formToSpawn[probability[Random.Range(0, probability.Count)]].Sign;
            Instantiate(toSpawn, spawnPoint, new Quaternion(0,0,0,0));
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
