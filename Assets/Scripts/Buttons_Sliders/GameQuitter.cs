using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//If Escape is pressed
        {
            QuitGame();//Call quit function
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");//Shows in Unity Editor

        Application.Quit();//Quits the built game
    }
}
