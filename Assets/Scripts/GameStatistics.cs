using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatistics
{
    private static int _currentLevel = -1;
    private static DateTime[,] _levelDurations = new DateTime[3,2];
    //private EventBroadcaster eb;

    //private GameStatistics()
    //{
    //    _levelDurations = new DateTime[3,2];
    //    eb = EventBroadcaster.Instance;

    //    eb.AddObserver(EventNames.LevelEvents.ON_LEVEL_START, OnLevelStart);
    //    eb.AddObserver(EventNames.LevelEvents.ON_LEVEL_END, OnLevelEnd);

    //}

    //public static GameStatistics Instance
    //{
    //    get { if (_instance == null) _instance = new GameStatistics(); return _instance; }
    //}

    public static void OnLevelStart()
    {
        CurrentLevel++;

        _levelDurations[CurrentLevel,0] = DateTime.Now;
        Debug.Log($"level start: {CurrentLevel}"); 
        //Debug.Log($"from game statistics: {GetDuration(CurrentLevel)}");
    }

    public static void OnLevelEnd()
    {
        _levelDurations[CurrentLevel, 1] = DateTime.Now;
        Debug.Log($"level end: {CurrentLevel}"); 
    }

    public static double GetDuration(int level)
    {
        Debug.Log("from getduration: " + (_levelDurations[level, 1] - _levelDurations[level, 0]).TotalSeconds);
        return (_levelDurations[level, 1] - _levelDurations[level, 0]).TotalSeconds;
    }

    public static double GetCurrentLevelDuration()
    {

        return GetDuration(CurrentLevel);
    }

    public static int CurrentLevel
    {
        get { return _currentLevel; } set { _currentLevel = value; }
    }
}
