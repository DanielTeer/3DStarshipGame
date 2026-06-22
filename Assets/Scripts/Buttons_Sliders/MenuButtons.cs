using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject pressEnterScreen;//Press Enter screen

    public GameObject mainMenuScreen;//Main menu screen

    public GameObject audioSettingsScreen;//Audio settings screen

    public GameObject gameplayScreen;//Gameplay HUD screen

    public GameObject gameOverScreen;//Game Over Screen

    public GameObject victoryScreen;//High Score screen

    public GameObject creditsScreen;//Credits screen

    private bool waitingForEnter = true;//Tracks if we are on press enter screen

    private void Start()
    {
        ShowPressEnterScreen();//Start on press enter screen
    }

    private void Update()
    {
        if (waitingForEnter && Input.anyKeyDown)//If any key is pressed on first screen
        {
            ShowMainMenu();//Go to main menu
        }
    }

    private void HideAllScreens()
    {
        if (pressEnterScreen != null)
        {
            pressEnterScreen.SetActive(false);//Hide press enter screen
        }

        if (mainMenuScreen != null)
        {
            mainMenuScreen.SetActive(false);//Hide main menu
        }

        if (audioSettingsScreen != null)
        {
            audioSettingsScreen.SetActive(false);//Hide audio settings
        }

        if (gameplayScreen != null)
        {
            gameplayScreen.SetActive(false);//Hide gameplay screen
        }

        if (victoryScreen != null) 
        {
            victoryScreen.SetActive(false);
        }

        if (gameOverScreen != null) 
        {
            gameOverScreen.SetActive(false);
        }

        if (creditsScreen != null)
        {
            creditsScreen.SetActive(false);
        }
    }

    public void ShowPressEnterScreen()
    {
        Time.timeScale = 0f;//Pause game

        waitingForEnter = true;//Allow Enter key to work

        HideAllScreens();//Hide everything

        if (pressEnterScreen != null)
        {
            pressEnterScreen.SetActive(true);//Show press enter screen
        }
    }

    public void ShowMainMenu()
    {
        Time.timeScale = 0f;//Keep game paused

        waitingForEnter = false;//Stop listening for Enter

        HideAllScreens();//Hide everything

        if (mainMenuScreen != null)
        {
            mainMenuScreen.SetActive(true);//Show main menu
        }
    }

    public void ShowAudioSettings()
    {
        Time.timeScale = 0f;//Keep game paused

        waitingForEnter = false;//Stop listening for Enter

        HideAllScreens();//Hide everything

        if (audioSettingsScreen != null)
        {
            audioSettingsScreen.SetActive(true);//Show audio settings
        }
    }

    public void StartGame()
    {
        if (GameManager.Instance != null)//If GameManager exists
        {
            GameManager.Instance.ResetGame();//Reset all gameplay data
        }

        Time.timeScale = 1f;//Unpause game

        waitingForEnter = false;//Stop waiting for enter

        HideAllScreens();//Hide menu screens

        if (gameplayScreen != null)//If gameplay screen exists
        {
            gameplayScreen.SetActive(true);//Show gameplay UI
        }
    }

    public void ShowVictoryScreen() 
    {
        Time.timeScale = 0f;

        waitingForEnter = false;

        HideAllScreens();

        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }
    }

    public void ShowGameOverScreen()
    {
        Time.timeScale = 0f;

        waitingForEnter = false;

        HideAllScreens();

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ShowCreditsScreen()
    {
        Time.timeScale = 0f;

        waitingForEnter = false;

        HideAllScreens();

        if (creditsScreen != null)
        {
            creditsScreen.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");//Shows in Unity Editor

        Application.Quit();//Quits built game
    }
}
