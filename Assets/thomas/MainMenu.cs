using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject winMenu;
    public GameObject loseMenu;

    private static bool win = false;
    private static bool lose = false;
    private static bool start = true;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }


    public static void BackToMenu()
    {
        start = true;
        win = false;
        lose = false;
    }

    public static void WinScreen()
    {
        win = true;
        start = false;
        lose = false;
    }

    public static void LoseScreen()
    {
        lose = true;
        start = false;
        win = false;
    }

    private void Update()
    {
        if (win == true)
        {
            winMenu.SetActive(true);
            mainMenu.SetActive(false);
            loseMenu.SetActive(false);
        }
        if (lose == true)
        {
            winMenu.SetActive(false);
            mainMenu.SetActive(false);
            loseMenu.SetActive(true);
        }
        if (start == true)
        {
            winMenu.SetActive(false);
            mainMenu.SetActive(true);
            loseMenu.SetActive(false);
        }
    }
}