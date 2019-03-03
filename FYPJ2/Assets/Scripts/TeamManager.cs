using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using SimpleJSON;

public class TeamManager : MonoBehaviour {

    public static TeamManager Instance;
    public GameObject GameOverMenu;
    public GameObject[] CharacterList;

    private GameObject[] PlayerTeam = new GameObject[3];
    private Stats[] CharacterStats = new Stats[3];
    private PlayerBattle[] CharacterBattles = new PlayerBattle[3];

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        string SelectedTeamPath = Application.streamingAssetsPath + "/PlayerTeam.json";
        if(File.Exists(SelectedTeamPath))
        {
            string SelectedTeamString = File.ReadAllText(SelectedTeamPath);
            JSONObject SelectedTeam = JSON.Parse(SelectedTeamString) as JSONObject;
            for (int index = 0; index < SelectedTeam["SelectedTeam"].Count; ++index)
            {
                for(int i = 0; i < CharacterList.Length; ++i)
                {
                    if (CharacterList[i].name != SelectedTeam["SelectedTeam"].AsArray[index])
                        continue;
                    GameObject Character = Instantiate(CharacterList[i], BattleCanvasInstance.Instance.transform.GetChild(index + 3));
                    CharacterBattles[index] = Character.GetComponent<PlayerBattle>();
                    CharacterStats[index] = Character.GetComponent<Stats>();
                    PlayerTeam[index] = Character;
                }
            }

        }


    }

    private void Update()
    {
        if (CheckCharSelection())
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;

        if (!CheckCharacterActive())
            GameOverMenu.SetActive(true);

    }

    //Return character gameobject at index
    public GameObject GetCharacter(int index) { return PlayerTeam[index]; }

    //Get character stats at index
    public Stats GetCharacterStats(int index) { return CharacterStats[index]; }

    //Get character playerbattle at index
    public PlayerBattle GetCharacterBattle(int index) { return CharacterBattles[index]; }

    private bool CheckCharSelection()
    {
        for(int i = 0; i < CharacterBattles.Length; ++i)
        {
            if (PlayerTeam[i] != null && CharacterBattles[i].GetCharSelect())
                return true;
        }
        return false;
    }

    private bool CheckCharacterActive()
    {
        for(int index = 0; index < 3; ++index)
        {
            if (GetCharacter(index) != null && GetCharacterStats(index).GetActive())
                return true;
            else if (!GetCharacterStats(index).GetActive())
                return false;
        }
        return false;
    }

    public void ReturnToTown()
    {
        SceneManager.LoadScene("TownScene");
    }
}
