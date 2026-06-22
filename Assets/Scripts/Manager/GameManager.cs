using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }//Singleton access

    public int score = 0;//Current score

    public int startingLives = 3;//Lives player starts with

    public int currentLives = 3;//Current lives during gameplay

    public int highScore = 0;//Best saved score

    public MenuButtons menuButtons;//Reference to menu script

    public PlayerDeath playerDeath;//Reference to player death/respawn script

    public AdditiveLevelLoader additiveLevelLoader;//Reference to chunk loader

    private bool gameIsOver = false;//Stops game over from happening multiple times

    public CameraFollow cameraFollow;//Reference to camera follow script

    private void Awake()
    {
        if (Instance == null)//No GameManager exists yet
        {
            Instance = this;//This becomes the GameManager
        }
        else
        {
            Destroy(gameObject);//Destroy duplicate
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);//Load saved high score
    }

    private void Start()
    {
        currentLives = startingLives;//Start with full lives
    }

    public void AddScore(int points)
    {
        if (gameIsOver)//If game already ended
        {
            return;//Do nothing
        }

        score += points;//Add points

        Debug.Log("Score: " + score);//Test score
    }

    public bool PlayerDied()
    {
        if (gameIsOver)//If game already ended
        {
            return false;//Do not respawn
        }

        currentLives--;//Lose one life

        Debug.Log("Lives: " + currentLives);//Test lives

        if (currentLives <= 0)//No lives left
        {
            GameOver();//Go to game over

            return false;//Do not respawn
        }

        return true;//Respawn player
    }

    private void GameOver()
    {
        gameIsOver = true;//Game has ended

        CheckHighScore();//Save high score if needed

        if (menuButtons != null)//If menu script exists
        {
            menuButtons.ShowGameOverScreen();//Show game over screen
        }
    }

    private void CheckHighScore()
    {
        if (score > highScore)//If current score beats saved high score
        {
            highScore = score;//Update high score

            PlayerPrefs.SetInt("HighScore", highScore);//Save high score

            PlayerPrefs.Save();//Force save
        }
    }

    public void ResetGame()
    {
        score = 0;//Reset score

        currentLives = startingLives;//Reset lives

        gameIsOver = false;//Allow game to run again

        if (additiveLevelLoader != null)//If chunk loader exists
        {
            additiveLevelLoader.ResetChunks();//Reset additive chunks
        }

        if (playerDeath != null)//If player death script exists
        {
            playerDeath.RespawnForNewGame();//Reset player
        }

        if (cameraFollow != null)//If camera follow exists
        {
            cameraFollow.SnapToTarget();//Snap camera to player
        }
    }
}