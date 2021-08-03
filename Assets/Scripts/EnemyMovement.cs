using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 1f;

    private float deltaSpeed;
    private Vector3 a, b;
    private bool targetReached;
    void Start()
    {
        a = transform.position;
        b = target.position;
        targetReached = false;
        transform.LookAt(target);
    }
    void FixedUpdate()
    {
        deltaSpeed = speed * Time.fixedDeltaTime;


        transform.position = Vector3.MoveTowards(transform.position, target.position, deltaSpeed);
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            targetReached = !targetReached;
            target.position = targetReached ? a : b;
            transform.LookAt(target);
        }
    }


}
