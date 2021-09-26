using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
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
        }
    }
}
