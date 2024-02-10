using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ballsLeftField;

    [SerializeField]
    TextMeshProUGUI scoreField;

    static float ballsLeft = 0;
    static float score = 0;

    const string ballsLeftPrefix = "Balls left: ";
    const string scorePrefix = "Score: ";

    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        ballsLeft = ConfigurationUtils.BallsPerGame;
        score = 0;

        ballsLeftField.text = ballsLeftPrefix + ballsLeft.ToString();
        scoreField.text = scorePrefix + score.ToString();

        EventManager.AddBallLostListener(BallLost);
        EventManager.AddPointsListener(GetPoints);
    }

    void Update()
    {
        ballsLeftField.text = ballsLeftPrefix + ballsLeft.ToString();
        scoreField.text = scorePrefix + score.ToString();

        int bricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        if (bricks == 0 && !gameOver)
        {
            gameOver = true;
            GameOver();
        }
    }

    void BallLost()
    {
        if (ballsLeft == 0)
        {
            GameOver();
        }
        else
        {
            AudioManager.Play(AudioName.BallLost);
            ballsLeft--;
        }
    }
    void GetPoints(float points)
    {
        score += points;
    }

    void GameOver()
    {
        AudioManager.Play(AudioName.GameOver);
        MenuManager.GoToMenu(MenuName.GameOver);
    }
}
