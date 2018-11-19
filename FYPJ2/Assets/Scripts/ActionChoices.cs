using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionChoices : MonoBehaviour {

    [SerializeField]
    GameObject SkillsList;

    [SerializeField]
    GameObject ItemsList;

    [SerializeField]
    GameObject AttackList;

    [SerializeField]
    private GraphicRaycaster Raycaster;
    [SerializeField]
    private EventSystem EventSystem;

    private bool SkillsActive = false;
    private bool ItemsActive = false;

    private bool TargetSelection = false;
    PointerEventData PointerEventData;

    private PlayerBattle playerBattle;
    private Stats playerStats;

    void Awake()
    {
        gameObject.SetActive(false);
        SkillsList.SetActive(false);
        ItemsList.SetActive(false);
        AttackList.SetActive(false);
    }

    void Start()
    {
        playerBattle = GetComponentInParent<PlayerBattle>();
        playerStats= GetComponentInParent<Stats>();

    }

    void Update()
    {
        if (TargetSelection)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Set up the new Pointer Event
                PointerEventData = new PointerEventData(EventSystem);
                //Set the Pointer Event Position to that of the mouse position
                PointerEventData.position = Input.mousePosition;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                Raycaster.Raycast(PointerEventData, results);

                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {
                    if(result.gameObject.tag == "Enemy")
                    {
                        Debug.Log(gameObject.transform.parent.name+ " Hit " + result.gameObject.name);
                        //To do : damage enemy here
                        EnemyBattle enemyBattle = result.gameObject.GetComponent<EnemyBattle>();
                        enemyBattle.TakeDamage(playerStats.GetDmg());

                        playerBattle.GetActionBar().value = 0.0f;

                        TargetSelection = false;
                        AttackList.SetActive(false);
                        gameObject.SetActive(false);
                        playerBattle.SetCharSelect(false);
                    }
                    else if(result.gameObject.tag == "Character")
                    {
                        TargetSelection = false;
                        gameObject.SetActive(false);
                        AttackList.SetActive(false);
                    }
                }
            }
        }

    }

    public void Attack()
    {
        TargetSelection = true;
        AttackList.SetActive(true);
    }

    public void SkillsListToggle()
    {
        SkillsList.SetActive(true);
        SkillsActive = true;
    }

    public void ItemsListToggle()
    {
        ItemsList.SetActive(true);
        ItemsActive = true;
    }

    public void BackButton()
    {
        if (SkillsActive)
        {
            SkillsList.SetActive(false);
            SkillsActive = false;
        }
        else if (ItemsActive)
        {
            ItemsList.SetActive(false);
            ItemsActive = false;
        }
        else if(TargetSelection)
        {
            TargetSelection = false;
            AttackList.SetActive(false);
        }
    }

}
