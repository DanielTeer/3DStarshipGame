using UnityEngine;
using UnityEngine.UI;

public class AudioSliders : MonoBehaviour
{
    public Slider masterSlider;//Master volume slider

    public Slider musicSlider;//Music volume slider

    public Slider sfxSlider;//SFX volume slider

    private void Start()
    {
        if (masterSlider != null)
        {
            masterSlider.value = 1f;//Start master at full volume
        }

        if (musicSlider != null)
        {
            musicSlider.value = 1f;//Start music at full volume
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = 1f;//Start SFX at full volume
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        if (AudioManager.Instance != null)//AudioManager exists
        {
            AudioManager.Instance.SetMasterVolume(volume);//Change master mixer volume
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        if (AudioManager.Instance != null)//AudioManager exists
        {
            AudioManager.Instance.SetMusicVolume(volume);//Change music mixer volume
        }
    }

    public void ChangeSFXVolume(float volume)
    {
        if (AudioManager.Instance != null)//AudioManager exists
        {
            AudioManager.Instance.SetSFXVolume(volume);//Change SFX mixer volume
        }
    }
}
