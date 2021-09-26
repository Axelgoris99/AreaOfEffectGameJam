using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject defeat;
    public GameObject shooter;
    [Header("Health")]
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private Hero heroStat;
    private int actualHealth;

    [Header("Time")]
    [SerializeField]
    private time timePass;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [Header("Signs")]
    private int currentNbOfPieces;
    [SerializeField]
    private TextMeshProUGUI nbOfSignCollected;

    // Update is called once per frame
    void OnEnable()
    {
        StartCoroutine(UpdateUI());
        actualHealth = heroStat.Health;
        healthText.text = actualHealth.ToString();
        timeText.text = timePass.timePassed.ToString();
        currentNbOfPieces = Signs.capturedSigns.Count;
        nbOfSignCollected.text = currentNbOfPieces.ToString();
    }

    public void Continue() {
        heroStat.SetHealth(3);
        heroStat.colli = true;
        Time.timeScale = 1;
        timePass.timePassed += 60;
        shooter.SetActive(true);
        defeat.SetActive(false);
    }


    IEnumerator UpdateUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            timeText.text = timePass.timePassed.ToString();
            int nbPieces = Signs.capturedSigns.Count;
            if (currentNbOfPieces != nbPieces)
            {
                currentNbOfPieces = nbPieces;
                nbOfSignCollected.text = nbPieces.ToString();
            }
            int heal = heroStat.Health;
            if (actualHealth != heal)
            {
                actualHealth = heal;
                healthText.text = heal.ToString();
            }
            if (actualHealth == 0)
            {
                Time.timeScale = 0;
                shooter.SetActive(false);
                defeat.SetActive(true);
            }
        }
    }
}
