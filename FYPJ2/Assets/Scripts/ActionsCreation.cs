using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Skills
{
    public Sprite skillIcon;
    public float skillCost;
    public string skillDesc;
}


public class ActionsCreation : MonoBehaviour {

    //Assign the list of character skills to this list
    private List<Skills> charSkills;

    [SerializeField]
    private GameObject samepleButton;

    [SerializeField]
    private Sprite image;

    void Awake()
    {
        charSkills = new List<Skills>();
        //Replace with actual list of character skills
        for (int i = 0; i < 4; ++i)// for testing *to remove*
        {
            Skills temp;
            temp.skillCost = 1.0f;
            temp.skillDesc = "";
            temp.skillIcon = image;
            charSkills.Add(temp);
        }



        for (int index = 0; index < charSkills.Count; ++index)
        {
            //Instantiate skill button 
            GameObject skillButton = Instantiate(samepleButton, transform);
            skillButton.GetComponent<Image>().sprite = charSkills[index].skillIcon; 
        }

        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
