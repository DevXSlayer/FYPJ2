using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour {

    [SerializeField]
    private GameObject PauseMenu;

	// Use this for initialization
	void Start () {
        PauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseOnClick()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        Time.timeScale = 0.0f;
    }

    public void ResumeOnClick()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

    }
}
