using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakePlayer
{
    [MenuItem("Assets/Create/Player")]
    public static void Create()
    {
        PlayerScriptable asset = ScriptableObject.CreateInstance<PlayerScriptable>();
        AssetDatabase.CreateAsset(asset, "Assets/Scripts/ScriptableObjects/PlayerStuff/Player.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}

