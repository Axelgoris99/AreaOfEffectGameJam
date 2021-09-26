using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Hero : MonoBehaviour
{
    [SerializeField]
    ParticleSystem system;
    AudioSource explode;
    [SerializeField]
    private GameObject gameManager;

    public bool colli;
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
        colli = true;
    }

    public void EndGame()
    {
        explode.Play();
        print("Perdu");
    }

    IEnumerator Invincible()
    {
        colli = false;
        yield return new WaitForSeconds(3f);
        colli = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") && colli)
        {
            StartCoroutine(Invincible());
            SetHealth(health - 1);
            system.Play();
        }
    }
}
