using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs : MonoBehaviour
{
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
        gameObject.SetActive(health > 1);  
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
}
