using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using SimpleJSON;
using UnityEngine;
using System.IO;

public class EmptyPlayerTeam {
    [MenuItem("Json/Create/PlayerTeamJson")]
    public static void EmptyPlayerTeamJson()
    {
        string PlayerTeamPath = Application.streamingAssetsPath + "/PlayerTeam.json";
        JSONObject Player= new JSONObject();
        Player.Add("PlayerGold", 200);
        JSONArray SelectedTeam = new JSONArray();
        
        //Adding 3 empty strings into a json array 
        for(int i = 0; i < 3; ++i)
        {
            SelectedTeam.Add("");
        }
        Player.Add("SelectedTeam", SelectedTeam);
        File.WriteAllText(PlayerTeamPath, Player.ToString());
    }
}
