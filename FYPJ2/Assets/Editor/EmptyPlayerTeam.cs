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
        JSONObject PlayerTeam = new JSONObject();
        File.WriteAllText(PlayerTeamPath, PlayerTeam.ToString());
    }

}
