using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    AudioSource explode;
    [SerializeField]
    private GameObject gameManager;
    
    [SerializeField]
    private int health;
    public int Health
    {
        get { return health; }
        set { SetHealth(value); }
    }

    public void SetHealth(int value)
    {
        health = Mathf.Max(value, 0);
        if (health == 0)
        {
            EndGame();
        }
    }

    void Start()
    {
        AudioSource[] explosions = GetComponents<AudioSource>();
        foreach(AudioSource audio in explosions)
        {
            if(audio.clip.name == "PlayerExplosion")
            {
                explode = audio;
                break;
            }
        }
    }

    public void EndGame()
    {
        explode.Play();
        print("Perdu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            SetHealth(health - 1);
        }
    }
}
