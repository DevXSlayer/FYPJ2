﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioSettingsManager : MonoBehaviour {

    public static AudioSettingsManager Instance;

    public Slider BGMSlider;
    public Slider SFXSlider;
    public GameObject TownButton;   //For when in battle
    public GameObject ConfirmationMenu;
    public GameObject SettingsMenu;
    public GameObject SettingsButton;
	// Use this for initialization
	void Awake () {
        Instance = this;
        DontDestroyOnLoad(this);
        TownButton.SetActive(false);
        ConfirmationMenu.SetActive(false);
        SettingsMenu.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex >= 3)
            SettingsButton.SetActive(true);
        else
            SettingsButton.SetActive(false);

        if (!SettingsMenu.activeSelf)
            return;

        BgmAudioManager.Instance.IncreaseAudio(BGMSlider.value);
        SFXAudioManager.Instance.IncreaseAudio(SFXSlider.value);

        if (SceneManager.GetActiveScene().buildIndex >= 4)
            TownButton.SetActive(true);
        else
            TownButton.SetActive(false);


            
	}

    public void SettingsMenuButton()
    {
        SettingsMenu.SetActive(!SettingsMenu.activeSelf);
    }

    public void ReturnToTown()
    {
        SceneManager.LoadScene("TownScene");
        SettingsMenu.SetActive(false);
        ConfirmationMenu.SetActive(false);
    }

    public void Confirmation()
    {
        ConfirmationMenu.SetActive(!ConfirmationMenu.activeSelf);
    }
}
