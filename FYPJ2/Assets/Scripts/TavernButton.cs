using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using SimpleJSON;


public class TavernButton : MonoBehaviour {

    public TextMeshProUGUI name;
    public TextMeshProUGUI costText;

    public int Cost;

    private PlayerVars player;
    private AudioSource source;
    private string CharListPath,PlayerTeamPath;
    private string CharListText, PlayerTeamText;
    private JSONObject CharHireList, PlayerTeamList;
    // Use this for initialization
    void Start()
    {
        player = PlayerVars.Instance;
        source = GetComponent<AudioSource>();
        CharListPath = Application.streamingAssetsPath + "/CharHireList.json";
        PlayerTeamPath = Application.streamingAssetsPath + "/PlayerTeamList.json";
        if (File.Exists(CharListPath))
        {
            CharListText = File.ReadAllText(CharListPath);
            CharHireList = JSON.Parse(CharListText) as JSONObject;
        }
        if (File.Exists(PlayerTeamPath))
        {
            PlayerTeamText = File.ReadAllText(PlayerTeamPath);
            PlayerTeamList = JSON.Parse(PlayerTeamText) as JSONObject;
        }

    }

    public void OnClick()
    {
        if (player.getGold() >= Cost )
        {
            player.reduceGold(Cost);
            CharHireList[name.text].AsArray[1].Value = "true";
            File.WriteAllText(CharListPath, CharHireList.ToString());            
            gameObject.SetActive(false);
        }
        //else
        //{
        //    source.Play();
        //}
    }
}
