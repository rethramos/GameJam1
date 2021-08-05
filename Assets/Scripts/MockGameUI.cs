using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MockGameUI : MonoBehaviour
{
    [SerializeField] private Text text;
    private Inventory inventory = Inventory.Instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string test = $"Jumps: {inventory.JumpCounter} Freeze: {inventory.FreezeCounter} Hints: {inventory.HintCounter}";
        text.text = test;
    }

    
}
