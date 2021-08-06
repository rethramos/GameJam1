using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_BackToMenu : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Final_MainMenu");
    }
}
