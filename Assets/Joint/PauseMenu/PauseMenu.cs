using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject shooter;
    public GameObject puzzle;
    public time time;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            
            if (!pause.activeSelf)
            {
                
                Time.timeScale = 0;
                shooter.SetActive(false);
                puzzle.SetActive(false);
                print(Signs.capturedSigns);
            }

            if (pause.activeSelf)
            {
                Time.timeScale = 1;
                shooter.SetActive(true);
            }
            pause.SetActive(!pause.activeSelf);
        }

        if (shooter.activeSelf && !time.enabled)
        {
            time.enabled = true;
        }
        if(!shooter.activeSelf && time.enabled)
        {
            time.enabled = false;
            time.StopAllCoroutines();
        }
    }

    public void ResumeShooter()
    {
        Time.timeScale = 1;
        shooter.SetActive(true);
        pause.SetActive(!pause.activeSelf);
    }

    public void ResumePuzzle()
    {
        Time.timeScale = 1;
        puzzle.SetActive(true);
        pause.SetActive(!pause.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
