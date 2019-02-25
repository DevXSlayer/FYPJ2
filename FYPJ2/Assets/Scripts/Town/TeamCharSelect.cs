using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using UnityEngine.UI;    

//Used to create the character buttons before entering battle
public class TeamCharSelect : MonoBehaviour {
    public GameObject CharButton;
    public Sprite[] CharSprite;

	// Use this for initialization
	void Start () {
        string CharListPath = Application.streamingAssetsPath + "/CharHireList.json";
        string PlayerTeamPath = Application.streamingAssetsPath + "/PlayerTeam.json";
        string CharListString = null;
        string PlayerTeamString = null;

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
                    if(PlayerTeam.Count > 0)
                    {
                        for (int TeamIndex = 0; TeamIndex < PlayerTeam.Count; ++TeamIndex)
                        {
                            if (PlayerTeam[TeamIndex.ToString()].Value == CharHireList[i].AsArray[0].Value)
                            {
                                Character.transform.SetParent(SelectedTeam.Instance.transform);
                                Character.GetComponent<TeamCharButton>().SetInTeam(transform);
                            }
                        }
                    }
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
                    Character.GetComponent<TeamCharButton>().SetInTeam(transform);
                }
            }
        }
	}


}
