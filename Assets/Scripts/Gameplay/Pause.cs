using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject PauseMenu = GameObject.Find("PauseMenu(Clone)");
            GameObject GameOverMenu = GameObject.Find("GameOverMenu(Clone)");

            if (PauseMenu == null && GameOverMenu == null)
            {
                MenuManager.GoToMenu(MenuName.Pause);
            }
   
        }
    }
}
