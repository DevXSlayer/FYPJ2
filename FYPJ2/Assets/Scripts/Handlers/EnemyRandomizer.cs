using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public enum EnemyType
{
    SLIME = 0,
    GOBLIN,
    RANDOM,
    TOTAL
};

public class EnemyRandomizer : MonoBehaviour
{

    //[SerializeField]
    //private EnemyType enemyType;

    //[SerializeField]
    //private Sprite[] enemySprites;




    private int factor;
    private int[] enemylist;

    private Image enemyImage;

    // Use this for initialization
    //void Start()
    //{

    //    enemyImage = GetComponent<Image>();

    //    if (enemyType == EnemyType.RANDOM)
    //    {
    //        int type = Random.Range(0, (int)EnemyType.TOTAL - 1);
    //        enemyType = (EnemyType)type;
    //    }

    //    // HARD COOOODE ~~~
    //    switch (enemyType)
    //    {
    //        case EnemyType.SLIME:
    //            enemyImage.sprite = enemySprites[0];
    //            break;

    //        case EnemyType.GOBLIN:
    //            enemyImage.sprite = enemySprites[1];
    //            break;
    //    }
    //}

}

