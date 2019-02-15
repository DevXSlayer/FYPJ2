using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamManager : MonoBehaviour {

    public static TeamManager Instance;
    public GameObject GameOverMenu;
    public TeamList FaryssTeamManager;
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
        //int playerAnchor = 3; //first anchor index
        //for (int i = 0; i < FaryssTeamManager.Team.Count; ++i)
        //{
        //    if (i >= 3)
        //        break;
        //    for (int x = 0; x < CharacterList.Length; ++x)
        //    {
        //        if (FaryssTeamManager.Team[i].name == CharacterList[x].name)
        //        {
        //            GameObject Character = Instantiate(CharacterList[x], BattleCanvasInstance.Instance.transform.GetChild(playerAnchor));
        //            Character.GetComponent<Stats>().SetHP(FaryssTeamManager.Team[i].Hp);
        //            Character.GetComponent<Stats>().SetDmg(FaryssTeamManager.Team[i].Dmg);
        //            Character.GetComponent<Stats>().SetArmor(FaryssTeamManager.Team[i].armor);

        //            PlayerTeam[i] = Character;
        //            CharacterStats[i] = PlayerTeam[i].GetComponent<Stats>();
        //            CharacterBattles[i] = PlayerTeam[i].GetComponent<PlayerBattle>();
        //            ++playerAnchor;
        //            break;
        //        }
        //    }
        //}
        int playerAnchor = 3; //first anchor index
        for (int i = 0; i < PlayerCheatScript.Instance.CheatList.Count; ++i)
        {
            if (i >= 3)
                break;
            for (int x = 0; x < CharacterList.Length; ++x)
            {
                if (PlayerCheatScript.Instance.CheatList[i].name == CharacterList[x].name)
                {
                    GameObject Character = Instantiate(CharacterList[x], BattleCanvasInstance.Instance.transform.GetChild(playerAnchor));
                    Character.GetComponent<Stats>().SetHP(PlayerCheatScript.Instance.CheatList[i].Hp);
                    Character.GetComponent<Stats>().SetDmg(PlayerCheatScript.Instance.CheatList[i].Dmg);
                    Character.GetComponent<Stats>().SetArmor(PlayerCheatScript.Instance.CheatList[i].armor);

                    PlayerTeam[i] = Character;
                    CharacterStats[i] = PlayerTeam[i].GetComponent<Stats>();
                    CharacterBattles[i] = PlayerTeam[i].GetComponent<PlayerBattle>();
                    ++playerAnchor;
                    break;
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
