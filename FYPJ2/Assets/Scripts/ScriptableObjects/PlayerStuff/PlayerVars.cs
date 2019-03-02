using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class PlayerVars : MonoBehaviour
{
    private static PlayerVars instance;

    public static PlayerVars Instance { get { return instance; } }
    //public PlayerScriptable PlayerScriptable;

    private int PlayerGold = 0;
    private string[] SelectedTeamNames = new string[3];

    // Use this for initialization
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Get Player previously selected team
        string PlayerTeamPath = Application.streamingAssetsPath + "/PlayerTeam.json";
        if (File.Exists(PlayerTeamPath))
        {
            string PlayerTeamString = File.ReadAllText(PlayerTeamPath);
            JSONObject PlayerTeam = JSON.Parse(PlayerTeamString) as JSONObject;
            PlayerGold = PlayerTeam["PlayerGold"];
            for (int index = 3; index < 3; ++index)
            {
                SelectedTeamNames[index] = PlayerTeam["SelectedTeam"].AsArray[index];
            }
        }
        Debug.Log(PlayerGold);
    }

    private void OnApplicationQuit()
    {
        //PlayerTeam.json should be created during editor phase
        //Saving gold and selected Team back to PlayerTeam.json
        string PlayerTeamPath = Application.streamingAssetsPath + "/PlayerTeam.json";
        string PlayerTeamString = File.ReadAllText(PlayerTeamPath);
        JSONObject PlayerTeam = JSON.Parse(PlayerTeamString) as JSONObject;
        PlayerTeam["PlayerGold"] = PlayerGold;
        for(int i = 0; i < 3; ++i)
        {
            PlayerTeam["SelectedTeam"].AsArray[i] = SelectedTeamNames[i];
        }
    }

    #region Gold Modifier functions
    public int getGold()
    {
        //return PlayerScriptable.gold;
        return PlayerGold;
    }

    public void reduceGold(int amount)
    {
        //PlayerScriptable.gold -= amount;
        PlayerGold -= amount;
    }

    public void AddGold(int amount)
    {
        //PlayerScriptable.gold += amount;
        PlayerGold += amount;
    }
    #endregion

    #region SelectedTeam Modifier functions
    public string[] GetSelectedTeamNames()
    {
        return SelectedTeamNames;
    }

    public void SetTeamCharNameInTeam(string name, int index)
    {
        SelectedTeamNames[index] = name;
    }
    
    public string GetSpecificIndexName(int index)
    {
        return SelectedTeamNames[index];
    }
    #endregion
}
