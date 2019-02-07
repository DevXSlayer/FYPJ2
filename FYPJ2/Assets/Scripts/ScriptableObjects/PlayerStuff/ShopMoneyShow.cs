using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMoneyShow : MonoBehaviour {

    private TextMeshProUGUI goldtext;

	// Use this for initialization
	void Start () {

        goldtext = GetComponent<TextMeshProUGUI>();
       // goldtext.text = "Gold : " + player.gold;
        goldtext.text = "Gold : " + PlayerVars.Instance.getGold();
    }
	
	// Update is called once per frame
	void Update () {
        goldtext.text = "Gold : " + PlayerVars.Instance.getGold();
    }
}
