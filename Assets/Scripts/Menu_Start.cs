using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Start : MonoBehaviour
{
    private EventBroadcaster eb = EventBroadcaster.Instance;
    public void Start_Game()
    {
        eb.PostEvent(EventNames.LevelEvents.ON_LEVEL_START);
        SceneManager.LoadScene("SceneGab");
        Debug.Log("called here: " + GameStatistics.GetCurrentLevelDuration());
        Debug.Log("ex: " + GameStatistics.CurrentLevel);
    }
}
