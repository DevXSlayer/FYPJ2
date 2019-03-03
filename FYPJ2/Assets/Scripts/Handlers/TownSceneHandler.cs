using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//More for handling UI that appears in town scene
public class TownSceneHandler : MonoBehaviour {

    private bool DungeonMenuOpen = false;
    private string SceneToChange;

    public GameObject TeamSelectionMenu;
    public GameObject DungeonMenu;
    public TeamCharSelect TeamChar;

    private void Start()
    {
        if(DungeonMenu != null)
        DungeonMenu.SetActive(false);
        if(TeamSelectionMenu !=null)
        TeamSelectionMenu.SetActive(false);
    }

    public void StartBattle()
    {
        TeamChar.StartBattle();
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

    public void DungeonMenuOpenClose()
    {
        DungeonMenuOpen = !DungeonMenuOpen;
        DungeonMenu.SetActive(!DungeonMenu.activeSelf);
    }
}
