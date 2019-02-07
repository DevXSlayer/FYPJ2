using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeWeaponObject{

    [MenuItem("Assets/Create/WeaponObject")]
    public static void Create()
    {
        WeaponObject asset = ScriptableObject.CreateInstance<WeaponObject>();
        AssetDatabase.CreateAsset(asset, "Assets/Scripts/ScriptableObjects/WeaponFiles/NewWeapon.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
