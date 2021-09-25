using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnShapes : MonoBehaviour
{
    public Color gizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    public List<Signs> collectedShapes = new List<Signs>();
    private Vector3 range;
    private Dictionary<string, int> inventaire = new Dictionary<string, int>();
    [SerializeField]
    public Dictionary<string, Button> buttons = new Dictionary<string, Button>();
    private Signs formeButton;

    private void Awake()
    {
        foreach(Signs sign in collectedShapes)
        {
            if(inventaire.ContainsKey(sign.name))
            {
                inventaire[sign.name] += 1;
            }
            else
            {
                inventaire.Add(sign.name, 1);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    public void SpawnShape(Signs forme)
    {
        formeButton = forme;
        //spawn la forme
        //
        //
        //décompte de l'inventaire
        inventaire[forme.name] -= 1;
        //update le compte texte sur le bouton
        //Text text = buttons[forme.name].transform.GetComponentInChildren<Text>();
        //text.text = "x " + inventaire[forme.name];

        //gérer le cas où plus de formes de ce ype = désactiver bouton
    }

    public void UpdateText(Text text)
    {
        text.text = "x " + inventaire[formeButton.name];
    }

}
