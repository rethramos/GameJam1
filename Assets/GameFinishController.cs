using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishController : MonoBehaviour
{
    [SerializeField] private Text messageText;
    private EventBroadcaster eb = EventBroadcaster.Instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        eb.AddObserver(EventNames.LevelEvents.ON_GAME_END, OnGameEnd);

    }

    private void OnDestroy()
    {
        eb.RemoveActionAtObserver(EventNames.LevelEvents.ON_GAME_END, OnGameEnd);
    }


    //[SerializeField] private Button nextLevelButton;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGameEnd()
    {
        gameObject.SetActive(true);
        messageText.text = $"Congratulations! You solved the maze in {GameStatistics.GetCurrentLevelDuration():N0} seconds. You are now reunited with Luna!";
    }
}
