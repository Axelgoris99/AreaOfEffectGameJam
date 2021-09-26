using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnShapes : MonoBehaviour
{
    public Color gizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    public List<Signs> collectedShapes = new List<Signs>();
    private Vector3 range;
    private Dictionary<string, int> inventaire = new Dictionary<string, int>();
    [SerializeField]
    public Dictionary<string, Button> buttons = new Dictionary<string, Button>();
    private Signs formeButton;
    private GameObject previousShape;

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
        if (!Manipulation.AnObjectIsHold)
        {
            formeButton = forme;
            //spawn la forme
            GameObject newShape = Instantiate(forme.gameObject, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (Camera.main.transform.position.y - 0.25f))), Quaternion.identity, null);

            //décompte de l'inventaire
            inventaire[forme.name] -= 1;

            previousShape = newShape;
        }
    }

    public void UpdateText(Button button)
    {
        if (!Manipulation.AnObjectIsHold)
        {
            TMP_Text text = button.transform.GetComponentInChildren<TMP_Text>();
            text.text = "x " + inventaire[formeButton.name];
            if (inventaire[formeButton.name] <= 0)
            {
                button.interactable = false;
            }
        }
    }
}
