using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.IO;

public class AudioSettingsManager : MonoBehaviour {

    public static AudioSettingsManager Instance;

    public Slider BGMSlider;
    public Slider SFXSlider;
    public GameObject TownButton;   //For when in battle
    public GameObject ConfirmationMenu;
    public GameObject SettingsMenu;
    public GameObject SettingsButton;

	void Start () {
        Instance = this;
        DontDestroyOnLoad(this);

        TownButton.SetActive(false);
        ConfirmationMenu.SetActive(false);
        SettingsMenu.SetActive(false);

        string DataPath = Application.streamingAssetsPath + "/AudioSettings.json";
        string AudioString = null;
        if (File.Exists(DataPath))
        {
            AudioString = File.ReadAllText(DataPath);
            JSONObject AudioJson = JSON.Parse(AudioString) as JSONObject;

            BGMSlider.value = AudioJson["BGM"];
            SFXSlider.value = AudioJson["SFX"];

            BgmAudioManager.Instance.IncreaseAudio(AudioJson["BGM"]);
            SFXAudioManager.Instance.IncreaseAudio(AudioJson["SFX"]);

        }
    }
	
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

    private void OnApplicationQuit()
    {
        JSONObject AudioJson = new JSONObject();
        AudioJson.Add("SFX", SFXSlider.value);
        AudioJson.Add("BGM", BGMSlider.value);

        string SavePath = Application.streamingAssetsPath + "/AudioSettings.json";
        File.WriteAllText(SavePath,AudioJson.ToString());
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
