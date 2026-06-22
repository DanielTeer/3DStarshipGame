using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreTMP;//Text that shows final score

    public TextMeshProUGUI highScoreTMP;//Text that shows high score

    private void OnEnable()
    {
        if (GameManager.Instance == null)//No GameManager exists
        {
            return;//Stop
        }

        if (finalScoreTMP != null)//If final score text exists
        {
            finalScoreTMP.text = "Final Score: " + GameManager.Instance.score;//Show final score
        }

        if (highScoreTMP != null)//If high score text exists
        {
            highScoreTMP.text = "High Score: " + GameManager.Instance.highScore;//Show high score
        }
    }
}
