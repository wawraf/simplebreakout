using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName menu)
    {
        switch (menu)
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;

            case MenuName.Help:
                GameObject MainMenuCanvas = GameObject.Find("MainMenuCanvas");

                if (MainMenuCanvas != null)
                {
                    MainMenuCanvas.SetActive(false);
                }

                Object.Instantiate(Resources.Load("HelpMenu"));
                break;

            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;

            case MenuName.GameOver:
                Object.Instantiate(Resources.Load("GameOverMenu"));
                break;
        }
    }

    
}
