using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    [SerializeField]
    public static GameObject playerShip;

    private void Start()
    {
        if(playerShip == null)
        {
             playerShip = GameObject.FindGameObjectWithTag("Player");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
