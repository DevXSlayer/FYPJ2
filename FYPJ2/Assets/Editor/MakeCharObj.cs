using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeCharObj {

    [MenuItem("Assets/Create/Character")]
    public static void Create()
    {
        CharacterObj asset = ScriptableObject.CreateInstance<CharacterObj>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Characters/NewChar.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}


