using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public static TeamManager Instance;

    private Stats[] PlayerTeam = new Stats[3];

    private PlayerBattle[] CharactersSelected = new PlayerBattle[3];
    void Awake()
    {
        Instance = this;
        //To change : to something more efficient
        GameObject[] characters = new GameObject[3]; 
        characters = GameObject.FindGameObjectsWithTag("Character");
        int charCount = 0;
        int selectionCount = 0;
        for(int index = 0; index < characters.Length; ++index)
        {
            if(characters[index].GetComponent<Stats>() != null)
            {
                PlayerTeam[charCount] = characters[index].GetComponent<Stats>();
                ++charCount;
            }
            if (characters[index].GetComponent<PlayerBattle>() != null)
            {
                CharactersSelected[selectionCount] = characters[index].GetComponent<PlayerBattle>();
                ++selectionCount;
            }
        }
    }
    

    public Stats GetTeamIndex(int index) { return PlayerTeam[index]; }
    public Stats[] GetTeam() { return PlayerTeam; }

    public bool CheckCharSelection()
    {
        for(int i = 0; i < CharactersSelected.Length; ++i)
        {
            if (CharactersSelected[i].GetCharSelect())
                return true;
        }
        return false;
    }
}
