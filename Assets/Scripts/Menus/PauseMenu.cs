using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Resume()
    {
        AudioManager.Play(AudioName.Click);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void Quit()
    {
        AudioManager.Play(AudioName.Click);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
