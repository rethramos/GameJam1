using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Start : MonoBehaviour
{
    public void Start_Game()
    {
        SceneManager.LoadScene("Maze");
    }
}
