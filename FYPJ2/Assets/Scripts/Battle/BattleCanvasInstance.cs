using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleCanvasInstance : MonoBehaviour {
    public static BattleCanvasInstance Instance;

    public GraphicRaycaster RayCaster;

    public BattleCanvasInstance()
    {
        Instance = this;
    }

    private void Start()
    {
        //Spawn player
        //for(int i = 0; i < TeamManager.Instance; ++i)
        //{
        //TeamManager.Instance.

        //}
    }
}
