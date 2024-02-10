using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{   
    public void StartGame()
    {
        AudioManager.Play(AudioName.Click);
        SceneManager.LoadScene("Gameplay");
    }

    public void HelpMenu()
    {
        AudioManager.Play(AudioName.Click);
        MenuManager.GoToMenu(MenuName.Help);
    }

    public void ExitGame()
    {
        AudioManager.Play(AudioName.Click);
        Application.Quit();
    }
}
