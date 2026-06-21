using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;//AudioSource used for player sounds

    private void Awake()
    {
        if (audioSource == null)//If not assigned
        {
            audioSource = GetComponent<AudioSource>();//Find AudioSource on player
        }
    }

    public void PlayClip(AudioClip clip)
    {
        if (audioSource == null)//No AudioSource
        {
            return;
        }

        if (clip == null)//No sound assigned
        {
            return;
        }

        audioSource.PlayOneShot(clip);//Play sound once
    }
}
