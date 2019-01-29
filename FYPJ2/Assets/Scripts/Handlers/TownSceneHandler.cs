using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownSceneHandler : MonoBehaviour {

   public void onClick()
    {
        SceneManager.LoadScene("BlackSmith Scene");
    }
}
