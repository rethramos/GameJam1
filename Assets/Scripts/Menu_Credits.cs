using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Credits : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
