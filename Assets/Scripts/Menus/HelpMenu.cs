using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void Back()
    {
        AudioManager.Play(AudioName.Click);
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
