using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapes : MonoBehaviour
{
    public Color gizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    public List<Signs> collectedShapes = new List<Signs>();
    private Vector3 range;
    private Dictionary<string, int> inventaire;

    private void Awake()
    {
        //range = transform.localScale / 2;
        //foreach(Signs sign in collectedShapes)
        //{
        //    Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
        //                                      Random.Range(-range.y, range.y),
        //                                      Random.Range(-range.z, range.z));
        //    GameObject newGO = Instantiate(sign.Sign.gameObject, transform.position + randomRange, transform.rotation, null);
        //    if(!newGO.TryGetComponent<Manipulation>(out Manipulation manip))
        //    {
        //        newGO.AddComponent<Manipulation>();
        //    }
        //}
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
