using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using UnityEngine.UI;    

//Used to create the character buttons before entering battle
public class TeamCharSelect : MonoBehaviour {
    public GameObject CharButton;
    public GameObject SelectedTeamHolder;
    public Sprite[] CharSprite;
    private string[] Team = new string[3];
    private int TeamCharCount = 0;


    // Use this for initialization
    void Start () {
        string CharListPath = Application.streamingAssetsPath + "/CharHireList.json";
        string PlayerTeamPath = Application.streamingAssetsPath + "/PlayerTeam.json";
        string CharListString = null;
        string PlayerTeamString = null;

        Team[0] = "";
        Team[1] = "";
        Team[2] = "";
        if (File.Exists(CharListPath) && CharSprite.Length > 0 && File.Exists(PlayerTeamPath))
        {
            CharListString = File.ReadAllText(CharListPath);
            PlayerTeamString = File.ReadAllText(PlayerTeamPath);
            JSONObject PlayerTeam = JSON.Parse(PlayerTeamString) as JSONObject;
            JSONObject CharHireList = JSON.Parse(CharListString) as JSONObject;
            
            for (int i = 0; i < CharHireList.Count; ++i)
            {
                if (CharHireList[i].AsArray[1])
                {
                    GameObject Character = Instantiate(CharButton, transform);
                    Character.GetComponent<TeamCharButton>().CharSelect = this;

                    for (int TeamIndex = 0; TeamIndex < PlayerTeam.Count; ++TeamIndex)
                    {
                        if(PlayerTeam["SelectedTeam"].AsArray[TeamIndex] != "")
                        {
                            if (PlayerTeam["SelectedTeam"].AsArray[TeamIndex] == CharHireList[i].AsArray[0].Value)
                            {
                                Character.transform.SetParent(SelectedTeamHolder.transform);
                                Character.GetComponent<TeamCharButton>().SetInTeam(transform);
                            }
                        }

                    }

                    //For setting sprite
                    for (int count = 0; count < CharSprite.Length; ++count)
                    {
                        if (CharSprite[count].name != CharHireList[i].AsArray[0].Value)
                            continue;
                        else
                        {
                            Character.GetComponent<Image>().sprite = CharSprite[count];
                            Character.name = CharSprite[count].name;
                        }
                    }
                    //Character.GetComponent<TeamCharButton>().SetInTeam(SelectedTeamHolder.transform);
                }
            }
        }
	}

    public bool SetCharacter(GameObject Character)
    {
        switch (TeamCharCount)
        {
            case 0:
                {
                    Team[0] = Character.name;
                    TeamCharCount++;
                    Character.transform.SetParent(SelectedTeamHolder.transform);
                    return true;
                }
            case 1:
                {
                    Team[1] = Character.name;
                    TeamCharCount++;
                    Character.transform.SetParent(SelectedTeamHolder.transform);
                    return true;
                }
            case 2:
                {
                    Team[2] = Character.name;
                    TeamCharCount++;
                    Character.transform.SetParent(SelectedTeamHolder.transform);
                    return true;
                }
            default:
                {
                    return false;
                }
        }
    }

    public void RemoveCharacter(GameObject Character)
    {
        switch (TeamCharCount)
        {
            case 1:
                {
                    Team[0] = "";
                    TeamCharCount--;
                    break;
                }
            case 2:
                {
                    Team[1] = "";
                    TeamCharCount--;
                    break;
                }
            case 3:
                {
                    Team[2] = "";
                    TeamCharCount--;
                    break;
                }
            default:
                {
                    break;
                }
        }

    }

    public void StartBattle()
    {
        string SavePath = Application.streamingAssetsPath + "/PlayerTeam.json";
        string SavePathString = File.ReadAllText(SavePath);
        JSONObject PlayerTeam = JSON.Parse(SavePathString) as JSONObject;
        for (int index = 0; index < 3; ++index)
        {
            PlayerTeam["SelectedTeam"].AsArray[index] = Team[index];
        }
        File.WriteAllText(SavePath, PlayerTeam.ToString());
    }
}
