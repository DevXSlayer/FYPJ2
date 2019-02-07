using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeTeamList{

    [MenuItem("Assets/Create/TeamList")]
    public static void Create()
    {
        TeamList asset = ScriptableObject.CreateInstance<TeamList>();
        AssetDatabase.CreateAsset(asset, "Assets/Scripts/ScriptableObjects/PlayerStuff/CurrentTeam.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
