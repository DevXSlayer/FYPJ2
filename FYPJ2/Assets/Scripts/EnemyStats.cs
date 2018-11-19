using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    [SerializeField]
    private int Hp;
    [SerializeField]
    private int Speed;
    [SerializeField]
    private int Armor;
    [SerializeField]
    private int MagicResist;
    [SerializeField]
    private int Dmg;
    [SerializeField]
    private int MagicDmg;

    public int GetHP() { return Hp; }
    public int GetSpeed() { return Speed; }
    public int GetArmor() { return Armor; }
    public int GetMagicResist() { return MagicResist; }
    public int GetDmg() { return Dmg; }
    public int GetMagicDmg() { return MagicDmg; }

    public void SetHP(int newHP) { Hp = newHP; }
    public void SetSpeed(int newSpeed) { Speed = newSpeed; }
    public void SetArmor(int newArmor) { Hp = newArmor; }
    public void SetMagicResist(int newMR) { Hp = newMR; }
    public void SetDmg(int newDmg) { Hp = newDmg; }
    public void SetMagicDmg(int newMDMG) { Hp = newMDMG; }


}
