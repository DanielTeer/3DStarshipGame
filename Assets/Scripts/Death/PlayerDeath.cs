using UnityEngine;

public class PlayerDeath : Death
{
    public float chunkLength = 100f;//Length of each level chunk

    public float respawnHeight = 10f;//How high above ground player respawns

    public float respawnZOffset = 50f;//Middle of current chunk

    public Vector3 newGameStartPosition = new Vector3(0f, 10f, 50f);//Starting position for new game

    public Health health;//Player health

    private Rigidbody rb;//Player Rigidbody

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();//Get Rigidbody

        if (health == null)//If health was not assigned
        {
            health = GetComponent<Health>();//Find Health on player
        }
    }

    public override void Die()
    {
        bool shouldRespawn = false;//Should player respawn?

        if (GameManager.Instance != null)//If GameManager exists
        {
            shouldRespawn = GameManager.Instance.PlayerDied();//Lose life and check lives
        }

        if (shouldRespawn)//If player still has lives
        {
            RespawnPlayer();//Respawn in current safe chunk
        }
    }

    public void RespawnPlayer()
    {
        ResetPlayerToPosition(GetSafeRespawnPosition());//Respawn inside current chunk
    }

    public void RespawnForNewGame()
    {
        ResetPlayerToPosition(newGameStartPosition);//Respawn at new game start
    }

    private void ResetPlayerToPosition(Vector3 position)
    {
        if (rb != null)//If Rigidbody exists
        {
            rb.linearVelocity = Vector3.zero;//Stop movement

            rb.angularVelocity = Vector3.zero;//Stop spinning
        }

        transform.position = position;//Move player

        transform.rotation = Quaternion.identity;//Reset rotation

        if (health != null)//If Health exists
        {
            health.ResetHealth();//Restore full health
        }
    }

    private Vector3 GetSafeRespawnPosition()
    {
        int currentChunkNumber = Mathf.FloorToInt(transform.position.z / chunkLength);//Find current chunk

        float safeZ = currentChunkNumber * chunkLength + respawnZOffset;//Middle of current chunk

        return new Vector3(0f, respawnHeight, safeZ);//Return safe position
    }
}