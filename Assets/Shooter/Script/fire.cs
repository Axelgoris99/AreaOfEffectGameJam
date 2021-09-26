using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField]
    GameObject ammo;
    float heat;
    bool overHeat;
    AudioSource laserBeam;
    void Start()
    {
        AudioSource[] lasers = GetComponents<AudioSource>();
        foreach (AudioSource audio in lasers)
        {
            if (audio.clip.name == "laser_15")
            {
                laserBeam = audio;
                break;
            }
        }
    }
    // Update is called once per frame
    private void OnEnable()
    {
        StartCoroutine("Fire");
        StartCoroutine("Cooldown");
    }

    private void Update()
    {
        if (heat > 1f)
        {
            overHeat = true;
        }
        if(overHeat && heat < 0)
        {
            overHeat = false;
        }
    }
    IEnumerator Cooldown()
    {
        while (true)
        {
            if (heat > 0 && overHeat)
            {
                heat -= 0.03f;
            }
            if(heat > 0 && !Input.GetButton("Fire1") && !overHeat)
            {
                heat -= 0.05f;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator Fire()
    {
        bool rightCanon = true;
        while (true)
        {
            if (Input.GetButton("Fire1") && !overHeat)
            {
                GameObject newAmmo;
                if (rightCanon)
                {
                    newAmmo = Instantiate(ammo, transform.position + transform.rotation * new Vector3(0.5f, 0.975f, 0f), transform.rotation);
                }
                else {
                    newAmmo = Instantiate(ammo, transform.position + transform.rotation * new Vector3(-0.5f, 0.975f, 0f) , transform.rotation);
                }
                newAmmo.SetActive(true);
                laserBeam.Play();
                rightCanon = !rightCanon;
                heat += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
