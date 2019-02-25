using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SimpleJSON;
using System.IO;

public class CharHireList {

    [MenuItem("Json/Create/Character")]
    public static void CreateHireList()
    {
        JSONObject CharList = new JSONObject();
        string CharObjPath = "Characters";

        CharacterObj[]CharObjs = Resources.LoadAll<CharacterObj>(CharObjPath);
        Debug.Log(CharObjs.Length);

        foreach (CharacterObj i in CharObjs)
        {
            JSONArray JArray= new JSONArray();
            JArray.Add(i.CharName);
            JArray.Add(false);
            CharList.Add(i.CharName, JArray);
        }


        string SavePath = Application.streamingAssetsPath + "/CharHireList.json";
        File.WriteAllText(SavePath, CharList.ToString());

    }
}
