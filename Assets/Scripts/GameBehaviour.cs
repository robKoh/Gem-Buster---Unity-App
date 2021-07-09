using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour gameBehaviour;

    public int score, highScore, currentSprite;
    public float time;
    public Text scoreText, highScoreText, timeText, pauseCurrentGameButtonText;
    public bool started, gameOver, gameIsPaused;
    private string resourceName = "backgrounds_images";
    private Sprite[] backgrounds;

    void Start()
    {
        Debug.Log("Start() in GameBehaviour");
        gameBehaviour = GetComponent<GameBehaviour>();
        StartGame();
    }

    private void Awake()
    {
        if (!resourceName.Equals(""))
        {
            Debug.Log("Awake called!");
            backgrounds = Resources.LoadAll<Sprite>(resourceName);

            foreach (Sprite sprite in backgrounds)
            {
                Debug.Log(sprite.name);
            }
        }
    }

    private void StartGame()
    {
        if (Time.timeScale == 0f)
        {
            pauseCurrentGameButtonText.text = "PAUSE GAME";
            Time.timeScale = 1;
        }

        started = true;
        gameOver = false;
        gameIsPaused = false;

        StartTimer();

        score = 0;

        scoreText.text = "Score: " + score;

        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + highScore;

        UpdateTime();
    }

    private void DoChangeBackground()
    {
        currentSprite = MenuBehaviour.currentSprite;

        GameObject.Find("GameUIPanel").GetComponent<Image>().sprite = backgrounds[currentSprite];
    }

    //Timer zählt sekündlich runter
    private void Update()
    {
        if (started)
        {
            if (!gameIsPaused)
            {
                time -= Time.deltaTime;
                UpdateTime();
                if (time <= 0)
                {
                    time = 0;
                    UpdateTime();
                    MenuBehaviour.LoadGameOverScene();
                }

                DoChangeBackground();
            }
        }
    }

    public void PauseCurrentGame()
    {
        gameIsPaused = !gameIsPaused;

        if (gameIsPaused)
        {
            pauseCurrentGameButtonText.text = "CONTINUE GAME";
            Time.timeScale = 0f;

        }
        else
        {
            pauseCurrentGameButtonText.text = "PAUSE GAME";
            Time.timeScale = 1;
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        Debug.Log("AddTime From Menu: " + MenuBehaviour.addTime);
        if (MenuBehaviour.addTime == 0)
        {
            //Default-Easy
            MenuBehaviour.addTime = 3;
            Debug.Log("AddTime - Default");
        } 

        time += MenuBehaviour.addTime;
        UpdateTime();
    }

    public void StartTimer()
    {
        time = 45;
        started = true;
    }

    public void UpdateTime()
    {
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");
        timeText.text = string.Format("Time: {0}:{1}", minutes, seconds);
    }

    public void BackToMenu()
    {
        MenuBehaviour.LoadMainMenu();
    }
}
