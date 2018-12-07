using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour {

    [SerializeField]
    private GameObject Overworld;
    [SerializeField]
    private GameObject Battle;


    private bool b_inbattle;

    public static BattleHandler Instance;

    void Start()
    {
        Instance = this;    

    }

    void Update()
    {
        if (b_inbattle)
        {
            Overworld.SetActive(false);
            Battle.SetActive(true);
            if (TeamManager.Instance.CheckEnemiesActive() == false)
            {
                Debug.Log("checking enemies");
                BattleHandler.Instance.setBattle(false);
            }
        }

        else
        {
            Overworld.SetActive(true);
            Battle.SetActive(false);
        }

    }

    public void setBattle(bool status)
    {
        b_inbattle = status;
    }


}
