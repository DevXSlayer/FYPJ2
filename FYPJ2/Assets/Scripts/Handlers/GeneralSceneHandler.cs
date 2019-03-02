using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//For handling general Scene changes
public class GeneralSceneHandler : MonoBehaviour {

    public void GoToBlacksmith()
    {
        SceneManager.LoadScene("BlackSmith Scene");
    }

    public void GoToTavern()
    {
        SceneManager.LoadScene("TavernScene");
    }

    public void GoToTown()
    {
        SceneManager.LoadScene("TownScene");
    }
}
