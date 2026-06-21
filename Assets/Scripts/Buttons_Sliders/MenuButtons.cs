using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject pressEnterScreen;//Press Enter screen

    public GameObject mainMenuScreen;//Main menu screen

    public GameObject audioSettingsScreen;//Audio settings screen

    public GameObject gameplayScreen;//Gameplay HUD screen

    private bool waitingForEnter = true;//Tracks if we are on press enter screen

    private void Start()
    {
        ShowPressEnterScreen();//Start on press enter screen
    }

    private void Update()
    {
        if (waitingForEnter && Input.GetKeyDown(KeyCode.Return))//If Enter is pressed on first screen
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
        Time.timeScale = 1f;//Unpause game

        waitingForEnter = false;//Stop listening for Enter

        HideAllScreens();//Hide everything

        if (gameplayScreen != null)
        {
            gameplayScreen.SetActive(true);//Show gameplay HUD
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");//Shows in Unity Editor

        Application.Quit();//Quits built game
    }
}
