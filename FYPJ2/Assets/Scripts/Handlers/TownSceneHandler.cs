using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownSceneHandler : MonoBehaviour {

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
}
