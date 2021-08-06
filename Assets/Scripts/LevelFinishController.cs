using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFinishController : MonoBehaviour
{
    [SerializeField] private Text messageText;
    // the scene name of the next level
    [SerializeField] private string nextLevelName;

    private EventBroadcaster eb = EventBroadcaster.Instance;

    //private string onLevelEndMessage = ;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        eb.AddObserver(EventNames.LevelEvents.ON_LEVEL_END, OnLevelEnd);
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        eb.RemoveActionAtObserver(EventNames.LevelEvents.ON_LEVEL_END, OnLevelEnd);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(nextLevelName);
        eb.PostEvent(EventNames.LevelEvents.ON_LEVEL_START);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    private void OnLevelEnd()
    {
        gameObject.SetActive(true);
        //Debug.Log("from onlevelendfinishcontroller:" + GameStatistics.Instance.)
        messageText.text = $"Congratulations! You solved the maze in {GameStatistics.GetCurrentLevelDuration():N0} seconds.";
    }
}
