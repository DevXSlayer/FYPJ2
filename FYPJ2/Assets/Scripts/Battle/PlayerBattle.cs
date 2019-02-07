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
    private Color DefaultColor;
    //Values that should take from the character 
    private float maxActionPoint = 1.0f;
    private float actionFillRate = 0.2f;

    private void Start()
    {
        DefaultColor = actionBar.fillRect.GetComponent<Image>().color;    
    }

    // Update is called once per frame
    void Update () {
        if (actionBar.value < maxActionPoint)
            actionBar.value += actionFillRate * Time.deltaTime;
        if (actionBar.value > 0.5)
            actionBar.fillRect.GetComponent<Image>().color = Color.yellow;
        else
            actionBar.fillRect.GetComponent<Image>().color = DefaultColor;


        if (charSelected)
            actionsList.SetActive(true);
        else
            actionsList.SetActive(false);
	}

    public void OnCharacterSelect() {
        charSelected = !charSelected;         
    }

    public void SetCharSelect(bool selection) { charSelected = selection; }

    public bool GetCharSelect() { return charSelected; }

    public Slider GetActionBar() { return actionBar; }
}
