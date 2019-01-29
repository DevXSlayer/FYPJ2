using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

  
    private GameObject BattleCanvas;

    [SerializeField]
    private GameObject EnemyPrefab;

    SLIMETYPES[] EnemyTypes;
    private GameObject PlayerObject;
    private bool Interacted = false;

    private void Start()
    {
        BattleCanvas = BattleCanvasInstance.Instance.gameObject;
    }

    private void Update()
    {
        PlayerObject = TeamManager.Instance.gameObject;
        if (CheckPlayerDistance() && !Interacted)
        {
            Interacted = true;
            SpawnEnemies();
            Debug.Log("Spawn Enemy");
        }
    }

    bool CheckPlayerDistance()
    {
        Vector2 Distance = (transform.position - PlayerObject.transform.position);
        if (Distance.magnitude < 0.001f)
            return true;
        return false;
    }

    void SpawnEnemies()
    {
        if (!BattleCanvas.activeSelf)
            BattleCanvas.SetActive(true);

        int NoOfEnemies = Random.Range(1, MaxNoEnemies + 1);

        EnemyTypes = new SLIMETYPES[NoOfEnemies];

        for (int EnemyIndex = 0; EnemyIndex < NoOfEnemies; ++EnemyIndex)
        {
            EnemyTypes[EnemyIndex] = (SLIMETYPES)(Random.Range(0, (int)SLIMETYPES.TOTAL));
        }

        for (int InitIndex = 0; InitIndex < EnemyTypes.Length; ++InitIndex)
        {
            GameObject Enemy = GameObject.Instantiate(EnemyPrefab, BattleCanvas.transform.GetChild(InitIndex));
            Enemy.GetComponent<Image>().sprite = SlimeSprites[(int)EnemyTypes[InitIndex]];
            Enemy.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = SlimeSprites[(int)EnemyTypes[InitIndex]].name;
            EnemyTeamManager.Instance.AddEnemy(Enemy, InitIndex);
        }
    }
}