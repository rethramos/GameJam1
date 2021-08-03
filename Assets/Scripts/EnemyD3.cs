using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyD3 : MonoBehaviour
{

    public Transform target;
    public Transform target1;
    public float speed;

    bool change = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        Vector3 c = target1.position;

        if (change)
        {
            transform.position = Vector3.MoveTowards(a, b, speed);
        }

        if (!change)
        {
            transform.position = Vector3.MoveTowards(a, c, speed);
        }

        if (transform.position.x >= 15.5f)
        {
            change = false;
        }

        if (transform.position.x <= 8.5f)
        {
            change = true;
        }

    }


}
