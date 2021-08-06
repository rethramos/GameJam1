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
