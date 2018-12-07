using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyBattle : MonoBehaviour
{

    //Character _character //Have a class to take in player properties

    [SerializeField]
    private Slider actionBar;


    //Values that should take from the character 
    private float maxActionPoint = 1.0f;
    //private float actionFillRate = 0.1f;
    private float attack_cost = 0.5f;
    private float skill_cost = 1.0f;
    private bool save_skill;
    private bool decided;
    private int factor;

    private Stats stats;

    void Awake()
    {
        //actionBar.value = 1.0f;  //maxActionPoint
    }

    // Use this for initialization
    void Start()
    {
       stats = GetComponent<Stats>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (actionBar.value < maxActionPoint)
            actionBar.value += stats.GetSpeed() * Time.deltaTime;


        if(!decided)
        {
            Decide();
        }

        if(!save_skill && actionBar.value >= 0.5f)
        {
            Attack();
        }

        if(save_skill && actionBar.value >= 1.0f)
        {
            UseSkill();
        }
    }

    void Attack()
    {
        //Debug.Log("I am attack");

        if(actionBar.value >= attack_cost)
        {
            actionBar.value -= attack_cost;
            bool checktarget = true;
            while (checktarget)
            {
                int choice = Random.Range(0, 3);
                if (TeamManager.Instance.GetTeamIndex(choice) != null && TeamManager.Instance.GetTeamIndex(choice).GetActive())
                {
                    TeamManager.Instance.GetTeamIndex(choice).ReduceHP(stats.GetDmg());
                    checktarget = false;
                }
            }


        }

        decided = false;
    }

    void UseSkill()
    {
        //Debug.Log("I am use of Skill");   

        if (actionBar.value >= skill_cost)
        {
            actionBar.value -= skill_cost;
            int choice = Random.Range(0, 3);
            if (TeamManager.Instance.GetTeamIndex(choice) != null && TeamManager.Instance.GetTeamIndex(choice).GetActive())
                TeamManager.Instance.GetTeamIndex(choice).ReduceHP(stats.GetDmg() * 5);
        }
        decided = false;
    }

    void Decide()
    {
        //Debug.Log("I am deciding");
        factor = Random.Range(0, 10);

        //Debug.Log("factor is " + factor);

        if (factor >= 7)
        {
            save_skill = true;
        }

        else
        {
            save_skill = false;
        }

        decided = true;

        //if(factor < 7.0f)
        //{
        //    //Attack();
        //}

        //else
        //{
        //    if(actionBar.value >= 1.0f)
        //    UseSkill();
        //}
    }

    public void TakeDamage(int damage) { stats.SetHP(stats.GetHP() - damage); }
}
