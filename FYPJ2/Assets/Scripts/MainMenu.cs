using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //YES
    public void GoToTownScene()
    {
        SceneManager.LoadScene("TownScene");
    }
}
