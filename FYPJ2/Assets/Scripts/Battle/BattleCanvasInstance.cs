using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCanvasInstance : MonoBehaviour {
    public static BattleCanvasInstance Instance;

    public BattleCanvasInstance()
    {
        Instance = this;
    }
}
