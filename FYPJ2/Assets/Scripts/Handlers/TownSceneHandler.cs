using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownSceneHandler : MonoBehaviour {

    private bool DungeonMenuOpen = false;
    private float MenuClosePosition;
    private float StartTime;
    public GameObject DungeonMenu;

    public List<GameObject> TeamList;

    private void Awake()
    {
        TeamList = new List<GameObject>();
    }
    private void Start()
    {

        MenuClosePosition = Screen.width/2;
        if (DungeonMenu != null) 
        DungeonMenu.SetActive(false);
    }

    public void Blacksmith()
    {
        SceneManager.LoadScene("BlackSmith Scene");
    }

    public void Battle()
    {
        SceneManager.LoadScene("ProtoBattleScene");
    }

    public void Tavern()
    {
        SceneManager.LoadScene("TavernScene");
    }

    public void Town()
    {
        SceneManager.LoadScene("TownScene");
    }


    public void DungeonMenuOpenClose()
    {
        DungeonMenuOpen = !DungeonMenuOpen;
        DungeonMenu.SetActive(!DungeonMenu.activeSelf);
    }
}
