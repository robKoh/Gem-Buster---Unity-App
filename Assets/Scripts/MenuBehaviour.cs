using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuBehaviour : MonoBehaviour
{
    public static MenuBehaviour menuBehaviour;
    public static float addTime;
    public static int currentSprite;
    public static int currentSoundStatus;

    void Start()
    {
        Debug.Log("Start() in MenuBehaviour");
        menuBehaviour = GetComponent<MenuBehaviour>();
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void LoadSettingsInMenu()
    {
        SceneManager.LoadScene("MenuSettings");
    }

    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void ExitApplication()
    {
        Debug.Log("has quit game.");
        Application.Quit();
    }
}
