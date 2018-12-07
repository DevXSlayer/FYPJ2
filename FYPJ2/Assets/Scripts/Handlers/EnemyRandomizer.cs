using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomizer : MonoBehaviour {

    private int factor;
    private int[] enemylist;


	// Use this for initialization
	void Start () {

        for (int i = 0; i < 4; ++i)
        {
            factor = Random.Range(0, 4);
            enemylist[i] = factor;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
