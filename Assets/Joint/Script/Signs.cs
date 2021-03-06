using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs : MonoBehaviour
{
    public static List<Signs> capturedSigns = new List<Signs>();
    public static spawnEnemy spawnCount;
    [SerializeField]
    private int health;
    [SerializeField]
    private GameObject sign;
    [SerializeField]
    private int score;
    [SerializeField]
    private int probability;

    [SerializeField]
    private string signName;
    public int Health
    {
        get { return health; }
        set { SetHealth(value); }
    }
    
    public void SetHealth(int value)
    {
        health = Mathf.Max(value, 0);
        if(health == 0)
        {
            DestructionSign();
        }
    }

    public int Probability
    {
        get { return probability; }
    }
    public int Score
    {
        get { return score; }
    }

    public GameObject Sign
    {
        get { return sign; }
    }

    public string SignName
    {
        get { return signName; }
    }

    private void Start()
    {
        if (spawnCount == null)
        {
            spawnCount = GameObject.FindGameObjectWithTag("Spawn").GetComponent<spawnEnemy>();
        }
    }

    public void DestructionSign() {
        capturedSigns.Add(this);
        spawnCount.NbOfEnemy = spawnCount.NbOfEnemy - 1;
        Destroy(gameObject);
    }
}
