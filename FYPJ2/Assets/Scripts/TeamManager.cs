using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public static TeamManager Instance;

    public GameObject[] PlayerTeam = new GameObject[3];
    private List<GameObject> Characters;
    private Stats[] PlayerStats = new Stats[3];
    private PlayerBattle[] CharactersSelected = new PlayerBattle[3];
    void Awake()
    {
        Instance = this;
        Characters = new List<GameObject>();

    }

    public GameObject GetTeamIndex(int index) { return PlayerTeam[index]; }
    public Stats GetTeamIndexStats(int index) { return Characters[index].GetComponent<Stats>(); }
    public GameObject[] GetTeam() { return PlayerTeam; }

    public bool CheckCharSelection()
    {
        for(int i = 0; i < Characters.Count; ++i)
        {
            if (Characters[i] != null && Characters[i].GetComponent<PlayerBattle>().GetCharSelect())
                return true;
        }
        return false;
    }

    public void AddCharacter(GameObject character)
    {
        Characters.Add(character);
    }
}
