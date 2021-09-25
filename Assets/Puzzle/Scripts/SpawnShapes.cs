using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapes : MonoBehaviour
{
    public Color gizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    public List<Signs> collectedShapes = new List<Signs>();
    private Vector3 range;
    private Dictionary<string, int> inventaire = new Dictionary<string, int>();

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
}
