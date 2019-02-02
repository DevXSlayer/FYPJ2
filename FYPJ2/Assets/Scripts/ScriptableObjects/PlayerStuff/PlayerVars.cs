using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVars : MonoBehaviour {

   public int gold = 0;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        gold = 200;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
