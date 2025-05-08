using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject exitMenu;

    public void Start()
    {
        exitMenu.SetActive(false);
    }

    public void OpenExitMenu()
    {
        exitMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        exitMenu.SetActive(false);
    }
}
