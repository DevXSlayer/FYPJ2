using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
public class SelectedTeam : MonoBehaviour {

    public static SelectedTeam Instance;
    private GameObject[] Team = new GameObject[3];

    private int TeamCharCount = 0;

    // Use this for initialization
    void Awake () {
        Instance = this;
	}

    public bool SetCharacter(GameObject Character)
    {
        switch (TeamCharCount)
        {
            case 0:
                {
                    Team[0] = Character;
                    TeamCharCount++;
                    Character.transform.SetParent(transform);
                    return true;
                }
            case 1:
                {
                    Team[1] = Character;
                    TeamCharCount++;
                    Character.transform.SetParent(transform);
                    return true;
                }
            case 2:
                {
                    Team[2] = Character;
                    TeamCharCount++;
                    Character.transform.SetParent(transform);
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
                    Team[0] = null;
                    TeamCharCount--;
                    break;
                }
            case 2:
                {
                    Team[1] = null;
                    TeamCharCount--;
                    break;
                }
            case 3:
                {
                    Team[2] = null;
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
        JSONObject PlayerTeam = new JSONObject();
        for (int index = 0; index < 3; ++index)
        { 
            PlayerTeam.Add(index.ToString(),Team[index].name);
        }
        File.WriteAllText(SavePath, PlayerTeam.ToString());
    }

}
