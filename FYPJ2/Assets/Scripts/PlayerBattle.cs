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

    void Awake()
    {
        //actionBar.value = 1.0f;  //maxActionPoint
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (actionBar.value < maxActionPoint)
            actionBar.value += actionFillRate * Time.deltaTime;
        
        if(charSelected)
        {
            // TO do make selection bar appear
            actionsList.SetActive(true);
        }   
        else
        {
            actionsList.SetActive(false);
        }
	}

    public void OnCharacterSelect()
    {
        //When player selects character for an action, etc
        if (!charSelected)  
        {
            charSelected = true;
            Time.timeScale = 0.0f;
        }
        //When player decides to cancel action selection
        else
        {
            charSelected = false;
            Time.timeScale = 1.0f;
        }
    }
}
