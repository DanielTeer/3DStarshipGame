using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI scoreTMP;//Text that shows score

    public TextMeshProUGUI livesTMP;//Text that shows lives

    private void Update()
    {
        if (GameManager.Instance == null)//No GameManager exists
        {
            return;//Stop
        }

        if (scoreTMP != null)//If score text exists
        {
            scoreTMP.text = "Score: " + GameManager.Instance.score;//Update score text
        }

        if (livesTMP != null)//If lives text exists
        {
            livesTMP.text = "Lives: " + GameManager.Instance.currentLives;//Update lives text
        }
    }
}
