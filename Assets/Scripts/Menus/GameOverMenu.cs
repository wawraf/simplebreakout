using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        AudioManager.Play(AudioName.Click);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
    public void ExitGame()
    {
        AudioManager.Play(AudioName.Click);
        Application.Quit();
    }
}
