using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatisticsManager : MonoBehaviour
{
    private EventBroadcaster eb = EventBroadcaster.Instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        eb.AddObserver(EventNames.LevelEvents.ON_LEVEL_START, OnLevelStart);
        eb.AddObserver(EventNames.LevelEvents.ON_LEVEL_END, OnLevelEnd);
    }

    private void OnDestroy()
    {
        eb.RemoveActionAtObserver(EventNames.LevelEvents.ON_LEVEL_START, OnLevelStart);
        eb.RemoveActionAtObserver(EventNames.LevelEvents.ON_LEVEL_END, OnLevelEnd);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLevelStart()
    {
        GameStatistics.OnLevelStart();
    }

    private void OnLevelEnd()
    {
        GameStatistics.OnLevelEnd();
    }
}
