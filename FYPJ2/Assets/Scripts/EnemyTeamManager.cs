using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamManager : MonoBehaviour {
    public static EnemyTeamManager Instance;

    private GameObject[] EnemyTeam = new GameObject[3];

    // Use this for initialization
    void Start () {
        Instance = this;
    }

    //If any enemies active return true, else return false 
    public bool CheckEnemiesActive()
    {
        for (int i = 0; i < EnemyTeam.Length; ++i)
        {
            if (EnemyTeam[i] == null)
                continue;
            if (EnemyTeam[i].activeSelf)
                return true;
        }
        return false;
    }

    public void AddEnemy(GameObject Enemy,int index)
    {
        EnemyTeam[index] = Enemy;
    }    
}
