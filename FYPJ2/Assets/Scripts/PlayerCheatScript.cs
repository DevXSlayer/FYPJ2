using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheatScript : MonoBehaviour {

    public static PlayerCheatScript Instance;


    public List<CharacterObj> CheatList = new List<CharacterObj>();
    public Dictionary<string, bool> CheatHireList = new Dictionary<string, bool>();
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

}
