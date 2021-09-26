using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnShapes : MonoBehaviour
{
    public GameObject puzzle;
    public Color gizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    
    private Vector3 range;
    private Dictionary<string, int> inventaire = new Dictionary<string, int>();
    [SerializeField]
    public Dictionary<string, Button> buttons = new Dictionary<string, Button>();
    private Signs formeButton;
    private GameObject previousShape;
    [SerializeField]
    private List<Button> buttonsList = new List<Button>();

    private void OnEnable()
    {
        
        foreach(Signs sign in Signs.capturedSigns)
        {
            if(inventaire.ContainsKey(sign.SignName))
            {
                inventaire[sign.SignName] += 1;
            }
            else
            {
                inventaire.Add(sign.SignName, 1);
            }
        }

        foreach (Button but in buttonsList)
        {
            TMP_Text text = but.transform.GetComponentInChildren<TMP_Text>();
            char[] chart = new char[1];
            chart[0] = ' ';
            string mot = but.gameObject.name.Split(chart)[0];
            if (inventaire.ContainsKey(mot))
            {
                text.text = "x " + inventaire[mot];
                if (inventaire[but.name] <= 0)
                {
                    but.interactable = false;
                }
            }
        }
    }


    public void SpawnShape(Signs forme)
    {
        if (!Manipulation.AnObjectIsHold && inventaire.ContainsKey(forme.SignName))
        {
            formeButton = forme;
            //spawn la forme
            GameObject newShape = Instantiate(forme.gameObject, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (Camera.main.transform.position.y - 0.25f))), Quaternion.identity, null);
            newShape.transform.parent = puzzle.transform;
            //décompte de l'inventaire
            inventaire[forme.SignName] -= 1;
            

            previousShape = newShape;
        }
    }

    public void UpdateText(Button button)
    {
        if (!Manipulation.AnObjectIsHold && inventaire.ContainsKey(button.name))
        {
            TMP_Text text = button.transform.GetChild(0).GetComponent<TMP_Text>();
            text.text = "x " + inventaire[formeButton.SignName];
            if (inventaire[formeButton.SignName] <= 0)
            {
                button.interactable = false;
            }
        }
    }

    public void printTruc()
    {
        print("Wow dement");
    }
}
