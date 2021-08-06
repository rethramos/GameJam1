using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyD1 : MonoBehaviour
{

    public Transform target;
    public Transform target1;
    public float speed;
    private EventBroadcaster eb = EventBroadcaster.Instance;
    private bool isFrozen;

    bool change = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        eb.AddObserver(EventNames.PowerupEvents.ON_FREEZE_USE, OnFreezeUse);

    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        eb.RemoveActionAtObserver(EventNames.PowerupEvents.ON_FREEZE_USE, OnFreezeUse);
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

        if (transform.position.z >= 8.0f)
        {
            change = false;
        }

        if (transform.position.z <= 2.0f)
        {
            change = true;
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
