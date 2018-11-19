using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBattle : MonoBehaviour {

    //Character _character //Have a class to take in player properties

    [SerializeField]
    private Slider actionBar;
    [SerializeField]
    private GameObject actionsList;

    //Variables used by this class itself
    private bool charSelected = false;

    //Values that should take from the character 
    private float maxActionPoint = 1.0f;
    private float actionFillRate = 0.2f;
	
	// Update is called once per frame
	void Update () {
        if (actionBar.value < maxActionPoint)
            actionBar.value += actionFillRate * Time.deltaTime;
        
        if(charSelected)
        {
            actionsList.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if (!charSelected && !TeamManager.Instance.CheckCharSelection())
        {
            actionsList.SetActive(false);
            Time.timeScale = 1.0f;
        }
	}

    public void OnCharacterSelect() {
        if(!TeamManager.Instance.CheckCharSelection())
        charSelected = !charSelected;
    }

    public void SetCharSelect(bool selection) { charSelected = selection; }
    public bool GetCharSelect() { return charSelected; }

    public Slider GetActionBar() { return actionBar; }
}
