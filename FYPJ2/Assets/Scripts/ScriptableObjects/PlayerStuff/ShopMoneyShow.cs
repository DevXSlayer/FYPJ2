using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMoneyShow : MonoBehaviour {

    public TextMeshProUGUI goldtext;
    public PlayerVars player;

	// Use this for initialization
	void Start () {

       // goldtext.text = "Gold : " + player.gold;
        goldtext.text = "Gold : " + PlayerVars.Instance.gold;
    }
	
	// Update is called once per frame
	void Update () {
        goldtext.text = "Gold : " + PlayerVars.Instance.gold;
    }
}
