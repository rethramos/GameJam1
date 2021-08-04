using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton class. Only one instance is allowed.
// To get the reference to the instance, call Inventory.Instance
public class Inventory
{
    private static Inventory _instance;
    private EventBroadcaster eb;

    private Inventory()
    {
        eb = EventBroadcaster.Instance;
        eb.AddObserver(EventNames.PowerupEvents.ON_FREEZE_COLLECT, OnFreezeCollect);
        eb.AddObserver(EventNames.PowerupEvents.ON_HINT_COLLECT, OnHintCollect);
        eb.AddObserver(EventNames.PowerupEvents.ON_JUMP_COLLECT, OnJumpCollect);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }

            return _instance;
        }
    }
    private void OnFreezeCollect()
    {
        FreezeCounter++;
    }
    private void OnJumpCollect()
    {
        JumpCounter++;
    }

    private void OnHintCollect()
    {
        HintCounter++;
    }

    public int FreezeCounter { get; set; }

    public int JumpCounter { get; set; }

    public int HintCounter { get; set; }

}
