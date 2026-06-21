using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }//Singleton access

    public int score = 0;//Current player score

    private void Awake()
    {
        if (Instance == null)//No GameManager exists yet
        {
            Instance = this;//This object becomes the GameManager
        }
        else
        {
            Destroy(gameObject);//Destroy duplicate GameManager
        }
    }

    public void AddScore(int points)
    {
        score += points;//Add points to score

        Debug.Log("Score: " + score);//Shows score in Console
    }
}