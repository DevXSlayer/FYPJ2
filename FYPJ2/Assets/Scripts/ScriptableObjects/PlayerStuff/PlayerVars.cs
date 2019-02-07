using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVars : MonoBehaviour {
    private static PlayerVars instance;

    public static PlayerVars Instance { get { return instance; } }
    public PlayerScriptable PlayerScriptable;

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
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getGold()
    {
        return PlayerScriptable.gold;
    }

    public void reduceGold(int amount)
    {
        PlayerScriptable.gold -= amount;
    }

    public void AddGold(int amount)
    {
        PlayerScriptable.gold += amount;
    }

}
