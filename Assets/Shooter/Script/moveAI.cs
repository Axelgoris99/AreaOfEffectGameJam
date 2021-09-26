using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;
public class moveAI : MonoBehaviour
{
    [SerializeField]
    float speed;
    public float Speed
    {
        get { return speed; }
        set { SetSpeed(value); }
    }
    public void SetSpeed(float value)
    {
        speed = value;
    }

    AIMContext aimContext;
    Vector3 oldDirection;
    Vector3 newDirection;
    List<Vector3> angleRotation = new List<Vector3>();
    int count = 0;
    Vector3 nextRotation = new Vector3();
    // Start is called before the first frame update
    void Awake()
    {
        aimContext = GetComponent<AIMContext>();
        oldDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        newDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        Vector3 add = Vector3.zero;
        for (int i = 0; i < 16; i++)
        {
            angleRotation.Add(add);
            angleRotation.Add(add);
        }
        add.z = 45;
        for(int i = 0; i< 8; i++)
        {
            angleRotation.Add(add);
            angleRotation.Add(-add);
        }
        add.z = 90;
        for (int i = 0; i < 2; i++)
        {
            angleRotation.Add(add);
            angleRotation.Add(-add);
        }
        count = angleRotation.Count;
        
    }

    private void OnEnable()
    {
        StartCoroutine(NextDirection());
    }

    IEnumerator NextDirection()
    {
        while (true)
        {
            nextRotation = angleRotation[Random.Range(0, count)];
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(speed > 5)
        {
            speed = 5;
        }
        newDirection = Quaternion.Euler(nextRotation) * oldDirection;
        nextRotation = new Vector3(0, 0, 0);
        newDirection.Normalize();
        if(aimContext.DecidedValues[0] > 0.1f)
        {
            newDirection = aimContext.DecidedDirection;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + newDirection, speed * Time.deltaTime);

        transform.up = newDirection;
        oldDirection = newDirection;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            nextRotation = new Vector3(0, 0, 180);
            speed *= 1.2f;
        }
    }

}
