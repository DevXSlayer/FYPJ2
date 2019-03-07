using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class TavernHiring : MonoBehaviour {

    public static TavernHiring Instance;
    private List<string> CharNameList = new List<string>();

	// Use this for initialization
	void Awake () {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;       
    }

    public void LeaveTavern()
    {
        if(CharNameList.Count > 0)
        {
            string CharHireListPath = Application.streamingAssetsPath + "/CharHireList.json";
            string CharHireListString = File.ReadAllText(CharHireListPath);
            JSONObject CharHireList = JSON.Parse(CharHireListString) as JSONObject;

            for (int i = 0; i < CharNameList.Count; ++i)
            {
                CharHireList[CharNameList[i]].AsArray[1] = true;
            }
            File.WriteAllText(CharHireListPath, CharHireList.ToString());
        }

        //SceneManager.LoadScene("TownScene");
    }

    public void HireCharacter(string charName)
    {
        CharNameList.Add(charName);
    }
}
