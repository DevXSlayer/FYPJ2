using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterObj : ScriptableObject{

    public string CharName = "Weapon Name Here";
    public int cost = 50;
    public Sprite CharSprite;

    public int Hp = 0;
    public int Dmg = 0;
    public float Ap_rate = 0;
    public float armor = 0;

    public bool hired = false;
    public bool available = false;

}
