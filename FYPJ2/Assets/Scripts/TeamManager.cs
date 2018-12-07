using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public static TeamManager Instance;

    private Stats[] PlayerTeam = new Stats[3];
    private GameObject[] EnemyTeam = new GameObject[3];

    private PlayerBattle[] CharactersSelected = new PlayerBattle[3];
    void Awake()
    {
        Instance = this;
        //To change : to something more efficient
        GameObject[] characters = new GameObject[3]; 
        characters = GameObject.FindGameObjectsWithTag("Character");

        GameObject[] enemies = new GameObject[3];
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        int charCount = 0;
        for (int index = 0; index < characters.Length; ++index)
        {
            PlayerTeam[charCount] = characters[index].GetComponent<Stats>();
            CharactersSelected[charCount] = characters[index].GetComponent<PlayerBattle>();
            ++charCount;

        }

        for (int index = 0; index < enemies.Length; ++index)
        {
            EnemyTeam[index] = enemies[index];
        }



    }
    

    public Stats GetTeamIndex(int index) { return PlayerTeam[index]; }
    public Stats[] GetTeam() { return PlayerTeam; }

    public bool CheckCharSelection()
    {
        for(int i = 0; i < CharactersSelected.Length; ++i)
        {
            if (CharactersSelected[i] != null &&CharactersSelected[i].GetCharSelect())
                return true;
        }
        return false;
    }

    //If any enemies active return true, else return false 
    public bool CheckEnemiesActive()
    {
        for (int i = 0; i < EnemyTeam.Length; ++i)
        {
            if (EnemyTeam[i] == null)
                continue;
            if (EnemyTeam[i].activeSelf)
                return true;
        }
        return false;
    }
}
