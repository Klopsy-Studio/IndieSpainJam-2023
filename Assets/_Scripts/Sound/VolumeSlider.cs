using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string parameter;

    [SerializeField] VolumeParent parent;
    [SerializeField] TextMeshProUGUI volumeNumber;
    [SerializeField] SoundType typeOfSlider;


    void Start()
    {
        switch (typeOfSlider)
        {
            case SoundType.SFX:

                if(AudioManager.instance.previousSfxVolume == 0.0001)
                {
                    volumeNumber.SetText("Mute");
                }
                else
                {
                    volumeNumber.SetText((AudioManager.instance.previousSfxVolume * 100).ToString());
                }
                parent.currentVolume = AudioManager.instance.previousSfxVolume;
                break;
            case SoundType.Music:
                if (AudioManager.instance.previousMusicVolume == 0.0001)
                {
                    volumeNumber.SetText("Mute");
                }
                else
                {
                    volumeNumber.SetText((AudioManager.instance.previousMusicVolume * 100).ToString());
                }
                parent.currentVolume = AudioManager.instance.previousMusicVolume;
                break;
            default:
                break;
        }
    }
    public void ReduceVolume()
    {
        if(parent.currentVolume == 0.0001f)
        {
            parent.currentVolume = 1;
            
        }
        else
        {
            parent.currentVolume -= 0.2f;

            if (parent.currentVolume <= 0.1)
            {
                parent.currentVolume = 0.0001f;
            }
        }
    
        mixer.SetFloat(parameter, Mathf.Log10(parent.currentVolume) * 20);

        if (parent.currentVolume == 1)
        {
            volumeNumber.SetText("100");
        }
        else if (parent.currentVolume == 0.0001f)
        {
            volumeNumber.SetText("Mute");
        }
        else
        {
            volumeNumber.SetText((parent.currentVolume * 100).ToString());
        }
    }

    public void AddVolume()
    {
        if (parent.currentVolume == 1)
        {
            parent.currentVolume = 0.0001f;
        }
        else
        {
            if(parent.currentVolume == 0.0001f)
            {
                parent.currentVolume = 0;
            }
            parent.currentVolume += 0.2f;

            if (parent.currentVolume >= 1)
            {
                parent.currentVolume = 1;
            }
        }

        mixer.SetFloat(parameter, Mathf.Log10(parent.currentVolume) * 20);

        if(parent.currentVolume == 1)
        {
            volumeNumber.SetText("100");
        }
        else if(parent.currentVolume == 0.0001f)
        {
            volumeNumber.SetText("Mute");
        }
        else
        {
            volumeNumber.SetText((parent.currentVolume *100).ToString());
        }

    }

    public void SaveVolume()
    {
        switch (typeOfSlider)
        {
            case SoundType.SFX:
                AudioManager.instance.previousSfxVolume = parent.currentVolume;
                break;
            case SoundType.Music:
                AudioManager.instance.previousMusicVolume = parent.currentVolume;
                break;
            default:
                break;
        }
    }


}
