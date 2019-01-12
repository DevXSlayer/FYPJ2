using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum SLIMETYPES
{
    NORMAL_SLIME = 0,
    RED_SLIME,
    BLUE_SLIME,
    TOTAL
}


public class SlimeRandomizer : MonoBehaviour {

    [SerializeField]
    private Sprite[] SlimeSprites;

    [SerializeField]
    private int MaxNoEnemies = 3;

    [SerializeField]
    private GameObject BattleCanvas;

    [SerializeField]
    private GameObject EnemyPrefab;

    SLIMETYPES[] EnemyTypes;
	// Use this for initialization
	void Start () {
        int NoOfEnemies = Random.Range(1, MaxNoEnemies + 1);

        EnemyTypes = new SLIMETYPES[NoOfEnemies];

        Debug.Log(NoOfEnemies);
        for(int EnemyIndex = 0; EnemyIndex < NoOfEnemies; ++EnemyIndex)
        {
            EnemyTypes[EnemyIndex] = (SLIMETYPES)(Random.Range(0, (int)SLIMETYPES.TOTAL));
        }
        
        for(int InitIndex = 0; InitIndex < EnemyTypes.Length; ++InitIndex)
        {
            GameObject Enemy = GameObject.Instantiate(EnemyPrefab,BattleCanvas.transform.GetChild(InitIndex));
            Enemy.GetComponent<Image>().sprite = SlimeSprites[(int)EnemyTypes[InitIndex]];
        }
    }



}
