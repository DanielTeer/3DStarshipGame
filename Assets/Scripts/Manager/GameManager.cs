using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static means this belongs to the class itself, not just one object.
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is no current GameManager, this object becomes the GameManager.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // If another GameManager already exists, destroy this duplicate.
            Destroy(gameObject);
        }
    }
}
