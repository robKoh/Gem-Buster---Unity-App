using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverBehaviour : MonoBehaviour
{
    public static GameOverBehaviour gameOverBehaviour;

    public Text gameOverScore, gameOverHighScore, gameOverDifficultyLevel;
    
    void Start()
    {
        Debug.Log("Start() in GameOverBehaviour");
        gameOverBehaviour = GetComponent<GameOverBehaviour>();
        GameOver();
    }

    public void GameOver()
    {
        GameBehaviour.gameBehaviour.started = false;
        GameBehaviour.gameBehaviour.gameOver = true;

        switch (MenuBehaviour.addTime)
        {
            case 3:
                Debug.Log("Difficulty Level: " + MenuBehaviour.addTime);
                gameOverDifficultyLevel.text = "Difficulty Level: Easy";
                break;
            case 1.75f:
                gameOverDifficultyLevel.text = "Difficulty Level: Medium";
                break;
            case 1:
                gameOverDifficultyLevel.text = "Difficulty Level: Hard";
                break;
        }

        gameOverScore.text = "Final Score: " + GameBehaviour.gameBehaviour.score;
        if (GameBehaviour.gameBehaviour.score > GameBehaviour.gameBehaviour.highScore)
        {
            gameOverHighScore.text = "High Score: " + GameBehaviour.gameBehaviour.score;
            PlayerPrefs.SetInt("HighScore", GameBehaviour.gameBehaviour.score);
        }
        else
        {
            gameOverHighScore.text = "High Score: " + GameBehaviour.gameBehaviour.highScore;
        }
    }

    public void PlayAgain()
    {
        MenuBehaviour.LoadGameScene();
    }

    public void BackToMenu()
    {
        MenuBehaviour.LoadMainMenu();
    }
}
