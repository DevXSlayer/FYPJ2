using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SFXAudioManager : MonoBehaviour {

    public static SFXAudioManager Instance;
    private AudioSource SFXAudio;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
        SFXAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    public void PlayAudio(AudioClip sfx)
    {
        SFXAudio.clip = sfx;
    }

    public void IncreaseAudio(float value)
    {
        SFXAudio.volume = value;
    }
}
