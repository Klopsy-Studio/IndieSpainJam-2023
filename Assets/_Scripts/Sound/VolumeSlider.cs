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


    private void Start()
    {
        volumeNumber.SetText((parent.currentVolume * 100).ToString());

    }
}
