using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyD6 : MonoBehaviour
{

    public Transform target;
    public Transform target1;
    public float speed;
    
    bool change = true;
    private SpriteRenderer spriteRenderer;
 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if(transform.position.z >= 16f)
        {
            change = false;
            spriteRenderer.flipX = true;
        }

        if(transform.position.z <= 2f)
        {
            change = true;
            spriteRenderer.flipX = false;
        }

    }

    
}
