using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

//Used to create the buttons to hire the Characters in the tarven
public class TavernCharacters: MonoBehaviour {
    public GameObject CharacterButton;

    public CharacterObj[] CharacterObjs;
	// Use this for initialization
	void Start () {
        string DataPath = Application.streamingAssetsPath + "/CharHireList.json";
        string CharText = null;

        if (File.Exists(DataPath))
        {
            CharText = File.ReadAllText(DataPath);
            JSONObject CharHireList = JSON.Parse(CharText) as JSONObject;

            for (int index = 0; index < CharacterObjs.Length; ++index)
            {
                if (!CharHireList[CharacterObjs[index].CharName].AsArray[1])
                {
                    GameObject Character = Instantiate(CharacterButton, transform);
                    TavernButton ButtonInfo;
                    Character.GetComponent<Image>().sprite = CharacterObjs[index].CharSprite;
                    ButtonInfo = Character.GetComponent<TavernButton>();
                    ButtonInfo.name.text = CharacterObjs[index].CharName;
                    ButtonInfo.costText.text = "$" + CharacterObjs[index].cost.ToString();
                    ButtonInfo.Cost = CharacterObjs[index].cost;
                }

            }
        }
	}
}
