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
        eb.AddObserver(EventNames.PowerupEvents.ON_JUMP_COLLECT, OnJumpCollect);
        eb.AddObserver(EventNames.PowerupEvents.ON_FREEZE_COLLECT, OnFreezeCollect);
        eb.AddObserver(EventNames.PowerupEvents.ON_HINT_COLLECT, OnHintCollect);

        eb.AddObserver(EventNames.PowerupEvents.ON_JUMP_USE, OnJumpUse);
        eb.AddObserver(EventNames.PowerupEvents.ON_FREEZE_USE, OnFreezeUse);
        eb.AddObserver(EventNames.PowerupEvents.ON_HINT_USE, OnHintUse);

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

    private void OnJumpCollect()
    {
        JumpCounter++;
    }

    private void OnFreezeCollect()
    {
        FreezeCounter++;
    }

    private void OnHintCollect()
    {
        HintCounter++;
    }

    private void OnJumpUse()
    {
        JumpCounter--;
    }

    private void OnFreezeUse()
    {
        FreezeCounter--;
    }

    private void OnHintUse()
    {
        HintCounter--;
    }

    public int FreezeCounter { get; set; }

    public int JumpCounter { get; set; }

    public int HintCounter { get; set; }

}