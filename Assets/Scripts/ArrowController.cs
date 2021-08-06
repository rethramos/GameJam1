using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private EventBroadcaster eb = EventBroadcaster.Instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        eb.AddObserver(EventNames.PowerupEvents.ON_HINT_USE, OnHintUse);
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

    public void OnHintUse()
    {

        gameObject.SetActive(true);
        StartCoroutine(ShowArrow());
    }

    public IEnumerator ShowArrow()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
