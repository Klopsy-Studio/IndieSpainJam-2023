using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public SoundType soundType;
    public bool loop;
    public bool playOnAwake;

    [HideInInspector] public float originalVolume;
    [Range(0f, 1f)] public float volume = 0.5f;
    [Range(0f, 2f)] public float pitch = 1f;

    [HideInInspector] public AudioSource source;
}

public enum SoundType
{
    SFX, Music
}
