using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BgmAudioManager : MonoBehaviour {

    public static BgmAudioManager Instance;

    public AudioClip TownBGM;
    public AudioClip BattleBGM;
    private AudioSource BGMaudio;
    private bool Town = false;
    private void Awake()
    {
        Instance = this;
        BGMaudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex < 4)
            PlayAudio(TownBGM);
        else if (SceneManager.GetActiveScene().buildIndex >= 4)
            PlayAudio(BattleBGM);               
    }

    public void PlayAudio(AudioClip bgm)
    {
        BGMaudio.clip = bgm;
        if (!BGMaudio.isPlaying)
            BGMaudio.Play();
    }

    public void IncreaseAudio(float value)
    {
        BGMaudio.volume = value;
    }
}
