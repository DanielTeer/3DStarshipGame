using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }//Singleton access

    public AudioMixer audioMixer;//The Audio Mixer asset

    private void Awake()
    {
        if (Instance == null)//No AudioManager exists yet
        {
            Instance = this;//This object becomes the AudioManager
        }
        else
        {
            Destroy(gameObject);//Destroy duplicate
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", ConvertToDecibel(volume));//Set master mixer volume
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", ConvertToDecibel(volume));//Set music mixer volume
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", ConvertToDecibel(volume));//Set SFX mixer volume
    }

    private float ConvertToDecibel(float volume)
    {
        if (volume <= 0.0001f)//Prevents math error at zero
        {
            return -80f;//Basically silent
        }

        return Mathf.Log10(volume) * 20f;//Converts slider value to mixer volume
    }
}