using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 25f;//How much health the player gains

    public AudioClip pickupSFX;//Health pickup sound

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();//Checks if player touched this

        if (player == null)//Not the player
        {
            return;
        }

        Health health = other.GetComponentInParent<Health>();//Find player's Health

        if (health == null)//Player has no Health component
        {
            return;
        }

        if (health.currentHealth >= health.maxHealth)//Player is already full health
        {
            return;
        }

        health.Heal(healAmount);//Heal player

        PlayerAudio playerAudio = player.GetComponent<PlayerAudio>();//Get PlayerAudio from player

        if (playerAudio != null)//If PlayerAudio exists
        {
            playerAudio.PlayClip(pickupSFX);//Play health pickup sound
        }

        Destroy(gameObject);//Destroy health pack
    }
}
