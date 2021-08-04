using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Player has quit.");
        Application.Quit();
    }
}
