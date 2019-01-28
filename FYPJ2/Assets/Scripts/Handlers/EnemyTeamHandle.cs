using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamHandle : MonoBehaviour {

    [SerializeField]
    private GameObject battleCanvas;

    [SerializeField]
    private GameObject[] enemies = new GameObject[3];
    
	// Use this for initialization
	void Start () {
        battleCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Triggers");
            BattleHandler.Instance.setBattle(true);
            battleCanvas.SetActive(true);
        }
    }
}
