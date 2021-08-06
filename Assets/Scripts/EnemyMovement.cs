using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 1f;

    private float deltaSpeed;
    private Vector3 a, b;
    private bool targetReached;
    private EventBroadcaster eb = EventBroadcaster.Instance;
    private bool isFrozen;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        eb.AddObserver(EventNames.PowerupEvents.ON_FREEZE_USE, OnFreezeUse);
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        eb.RemoveActionAtObserver(EventNames.PowerupEvents.ON_FREEZE_USE, OnFreezeUse);
    }



    void Start()
    {
        a = transform.position;
        b = target.position;
        targetReached = false;
        isFrozen = false;
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

    private void OnFreezeUse()
    {
        Debug.Log("monster on freeze use");
        if (!isFrozen) StartCoroutine(Freeze());
    }

    private IEnumerator Freeze()
    {
        float def = speed;
        speed = 0f;
        Debug.Log("monsters freezed.");
        isFrozen = true;
        yield return new WaitForSeconds(5f);
        speed = def;
        Debug.Log("monsters unfreezed.");
        isFrozen = false;
    }
}
