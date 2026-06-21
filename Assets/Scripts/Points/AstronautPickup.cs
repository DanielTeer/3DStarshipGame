using UnityEngine;

public class AstronautPickup : MonoBehaviour
{
    public int points = 100;//Points gained for pickup

    public AudioClip pickupSFX;//Astronaut pickup sound

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();//Checks if player touched this

        if (player == null)//Not player
        {
            return;
        }

        if (GameManager.Instance != null)//GameManager exists
        {
            GameManager.Instance.AddScore(points);//Add points
        }

        PlayerAudio playerAudio = player.GetComponent<PlayerAudio>();//Get PlayerAudio from player

        if (playerAudio != null)//If PlayerAudio exists
        {
            playerAudio.PlayClip(pickupSFX);//Play astronaut pickup sound
        }

        Destroy(gameObject);//Remove astronaut after pickup
    }
}
