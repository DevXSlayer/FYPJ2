using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsButtonCreation : MonoBehaviour {

    //Assign the list of character skills to this list
    private Skills[] charSkills;

    [SerializeField]
    private GameObject samepleButton;

    private Stats charStats;

    void Start()
    {
        charStats = GetComponentInParent<Stats>();
        SkillsCreate();
    }

    public void SkillsCreate()
    {
        charSkills = charStats.GetSkills();

        for (int i = 0; i < charSkills.Length; ++i)
        {
            //Instantiate skill button 
            GameObject skillButton = Instantiate(samepleButton, transform);
            skillButton.GetComponent<Image>().sprite = charSkills[i].skillIcon;
        }
    }
}
