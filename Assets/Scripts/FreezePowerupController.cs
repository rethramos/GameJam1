using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerupController : MonoBehaviour
{
    private EventBroadcaster eb = EventBroadcaster.Instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        eb.AddObserver(EventNames.PowerupEvents.ON_FREEZE_COLLECT, OnCollect);
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        eb.RemoveObserver(EventNames.PowerupEvents.ON_FREEZE_COLLECT);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Observer for when a player collects this powerup
    private void OnCollect()
    {
        Debug.Log("from freezepowerupcont: " + EventNames.PowerupEvents.ON_FREEZE_COLLECT);
        gameObject.SetActive(false);
    }
}
