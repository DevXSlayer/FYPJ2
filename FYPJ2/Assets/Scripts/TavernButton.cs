﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;


public class TavernButton : MonoBehaviour {

    public int MemberNumber;

    private PlayerVars player;

    public TeamList TavernList;
    public TeamList CurrTeam;

    public TextMeshProUGUI name;
    public TextMeshProUGUI cost;

    private AudioSource source;
    // Use this for initialization
    void Start()
    {
        player = PlayerVars.Instance;
        source = GetComponent<AudioSource>();
        SetButton();
        if (TavernList.Team[MemberNumber].hired == true)
            gameObject.SetActive(false);
        //player = player.GetComponent<PlayerVars>();
    }

    void SetButton()
    {
        string costString = TavernList.Team[MemberNumber].cost.ToString();
        name.text = TavernList.Team[MemberNumber].name;
        cost.text = "$" + TavernList.Team[MemberNumber].cost;
        gameObject.GetComponent<Image>().sprite = TavernList.Team[MemberNumber].CharSprite;
    }

    public void OnClick()
    {
        if (player.getGold() >= TavernList.Team[MemberNumber].cost)
        {

            player.reduceGold(TavernList.Team[MemberNumber].cost);
            PlayerCheatScript.Instance.CheatList.Add(TavernList.Team[MemberNumber]);
            //TavernList.Team.Remove(TavernList.Team[MemberNumber]);
            CurrTeam.Team.Add(TavernList.Team[MemberNumber]);
            TavernList.Team[MemberNumber].hired = true;
            
            

            if (TavernList.Team[MemberNumber].hired == true)
            gameObject.SetActive(false);

        }
        //else
        //{
        //    source.Play();
        //}
    }

    public void  AddStats()
    {

    }

}
