using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownSceneHandler : MonoBehaviour {

    private bool DungeonMenuOpen = false;
    private float MenuClosePosition;
    private float StartTime;
    private string SceneToChange;

    public GameObject TeamSelectionMenu;
    public GameObject DungeonMenu;

    public List<GameObject> TeamList;

    private void Awake()
    {
        TeamList = new List<GameObject>();
    }
    private void Start()
    {

        MenuClosePosition = Screen.width/2;
        if(DungeonMenu != null)
        DungeonMenu.SetActive(false);
        if(TeamSelectionMenu !=null)
        TeamSelectionMenu.SetActive(false);
    }

    public void Blacksmith()
    {
        SceneManager.LoadScene("BlackSmith Scene");
    }

    public void StartBattle()
    {
        SelectedTeam.Instance.StartBattle();
        TeamSelectionMenu.SetActive(false);
        SceneManager.LoadScene(SceneToChange);
    }
    public void SelectDungeon(string SceneName)
    {
        SceneToChange = SceneName;
        DungeonMenu.SetActive(false);
        TeamSelectionMenu.SetActive(true);
    }
    public void TeamSelectBack()
    {
        DungeonMenu.SetActive(true);
        TeamSelectionMenu.SetActive(false);
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
