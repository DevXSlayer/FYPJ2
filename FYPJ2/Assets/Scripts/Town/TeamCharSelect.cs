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
    private int InTeamCount = 0;

    // Use this for initialization
    void Start () {
        Team = PlayerVars.Instance.GetSelectedTeamNames();
        string CharListPath = Application.streamingAssetsPath + "/CharHireList.json";

        if (File.Exists(CharListPath) && CharSprite.Length > 0)
        {
            string CharListString = File.ReadAllText(CharListPath);
            JSONObject CharHireList = JSON.Parse(CharListString) as JSONObject;
            
            for (int i = 0; i < CharHireList.Count; ++i)
            {
                if (CharHireList[i].AsArray[1])
                {
                    GameObject Character = Instantiate(CharButton, transform);
                    Character.name = CharHireList[i].AsArray[0].Value;
                    Character.GetComponent<TeamCharButton>().CharSelect = this;

                    //Only if there isn't 3 characters in team then we check 
                    if(InTeamCount < 3)
                    {
                        //If this character from CharHireList is saved in the list of player selected team
                        if (PlayerVars.Instance.FindInSelectedTeamNames(CharHireList[i].AsArray[0]))
                        {
                            SetCharacter(Character);
                            Character.GetComponent<TeamCharButton>().SetInTeam(transform);
                            ++InTeamCount;
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
        //string SavePath = Application.streamingAssetsPath + "/PlayerTeam.json";
        //string SavePathString = File.ReadAllText(SavePath);
        //JSONObject PlayerTeam = JSON.Parse(SavePathString) as JSONObject;
        //for (int index = 0; index < 3; ++index)
        //{
        //    PlayerTeam["SelectedTeam"].AsArray[index] = Team[index];
        //}
        //File.WriteAllText(SavePath, PlayerTeam.ToString());
        Debug.Log(Team);
        for (int index = 0; index < 3; ++index)
        {
            PlayerVars.Instance.SetTeamCharNameInTeam(Team[index], index);
        }

    }
}
