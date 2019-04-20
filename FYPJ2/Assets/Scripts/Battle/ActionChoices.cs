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

    private bool SkillsActive = false;
    private bool ItemsActive = false;

    private bool TargetSelection = false;
    private PointerEventData PointerEventData;
    private PlayerBattle playerBattle;
    private Stats playerStats;
    private GraphicRaycaster Raycaster;
    private EventSystem EventSystem;
    public Animator animator;

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
        playerStats = GetComponentInParent<Stats>();
        Raycaster = BattleCanvasInstance.Instance.RayCaster;
        EventSystem = BattleCanvasInstance.Instance.EventSystem;
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
                    checkClickedTarget(result);
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

    void checkClickedTarget(RaycastResult result)
    {
        if (result.gameObject.tag == "Enemy")
        {
            //To do : damage enemy here
            EnemyBattle enemyBattle = result.gameObject.GetComponent<EnemyBattle>();
            enemyBattle.TakeDamage(playerStats.GetDmg());

            playerBattle.GetActionBar().value = 0.0f;
            if(animator != null)
            {
                animator.SetTrigger("Attack");
                Debug.Log("AnimAtk");
            }

            TargetSelection = false;
            AttackList.SetActive(false);
            gameObject.SetActive(false);
            playerBattle.SetCharSelect(false);
        }
        else if (result.gameObject.layer == 8)//Character Layer
        {
            AttackList.SetActive(false);
            TargetSelection = false;
        }

    }
}
