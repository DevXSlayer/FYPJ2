using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BattleCanvasInstance : MonoBehaviour {
    public static BattleCanvasInstance Instance;

    public GraphicRaycaster RayCaster;
    public EventSystem EventSystem;

    public BattleCanvasInstance()
    {
        Instance = this;
    }

    private void Start()
    {
        //Spawn player
        int PlayerAnchor = 3;
        for(int i = 0; i < TeamManager.Instance.GetTeam().Length; ++i)
        {
            GameObject Character = Instantiate(TeamManager.Instance.GetTeamIndex(i), BattleCanvasInstance.Instance.transform.GetChild(PlayerAnchor));
            TeamManager.Instance.AddCharacter(Character);
            ++PlayerAnchor;
        }
    }
}
