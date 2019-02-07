using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamManager : MonoBehaviour {

    public static TeamManager Instance;
    public GameObject GameOverMenu;
    public GameObject[] FaryssTeamManager = new GameObject[3];

    private GameObject[] PlayerTeam = new GameObject[3];
    private Stats[] CharacterStats = new Stats[3];
    private PlayerBattle[] CharacterBattles = new PlayerBattle[3];

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int playerAnchor = 3; //first anchor index
        for(int index = 0;index < FaryssTeamManager.Length; ++index)
        {
            GameObject Character = Instantiate(FaryssTeamManager[index], BattleCanvasInstance.Instance.transform.GetChild(playerAnchor));
            PlayerTeam[index] = Character;
            CharacterStats[index] = PlayerTeam[index].GetComponent<Stats>();
            CharacterBattles[index] = PlayerTeam[index].GetComponent<PlayerBattle>();
            ++playerAnchor;
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
            if (GetCharacter(index) != null && GetCharacter(index).activeSelf)
                return true;
            else
                return false;
        }
        return false;
    }

    public void ReturnToTown()
    {
        SceneManager.LoadScene("TownScene");
    }
}
