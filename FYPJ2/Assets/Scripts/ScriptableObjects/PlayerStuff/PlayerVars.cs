using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVars : MonoBehaviour {
    private static PlayerVars instance;
   public int gold = 200;


    public static PlayerVars Instance { get { return instance; } }


    // Use this for initialization
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
