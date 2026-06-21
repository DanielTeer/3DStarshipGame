using UnityEngine;

public class PlayerYLimit : MonoBehaviour
{
    public LevelData levelData;//The level that stores the Y limit

    private Rigidbody rb;//Player Rigidbody

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();//Try to get Rigidbody from this object
    }

    private void LateUpdate()
    {
        if (levelData == null)//If no level data is assigned yet
        {
            levelData = FindFirstObjectByType<LevelData>();//Try to find level data again
        }

        if (levelData == null)//If still no level data exists, stop
        {
            return;
        }

        if (transform.position.y > levelData.playerYLimit)//If player goes above the Y limit
        {
            Vector3 limitedPosition = transform.position;//Copy current position

            limitedPosition.y = levelData.playerYLimit;//Change only the Y value

            transform.position = limitedPosition;//Move player back to the Y limit

            if (rb != null && rb.linearVelocity.y > 0f)//If Rigidbody exists and player is moving upward
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);//Stop upward velocity
            }
        }
    }
}