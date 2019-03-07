using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using SimpleJSON;


public class TavernButton : MonoBehaviour {

    public TextMeshProUGUI name;
    public TextMeshProUGUI costText;
    public int Cost;

    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        if (PlayerVars.Instance.getGold() >= Cost )
        {
            PlayerVars.Instance.reduceGold(Cost);
            TavernHiring.Instance.HireCharacter(name.text);
            gameObject.SetActive(false);
        }
        //else
        //{
        //    source.Play();
        //}
    }
}
