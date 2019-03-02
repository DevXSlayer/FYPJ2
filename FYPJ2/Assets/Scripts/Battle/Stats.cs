using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour {

    [SerializeField]
    private Slider HeatlhBar;

    [SerializeField]
    private int Hp;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private int Armor;
    [SerializeField]
    private int MagicResist;
    [SerializeField]
    private int Dmg;
    [SerializeField]
    private int MagicDmg;

    [SerializeField]
    private Skills[] skillSet;

    public bool active = true;

    void Start()
    {
        HeatlhBar.maxValue = Hp;
        HeatlhBar.value = Hp;        
    }

    void Update()
    {
        HeatlhBar.value = Hp;
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
            active = false;
        }
    }

    public int GetHP() { return Hp; }
    public float GetSpeed() { return Speed; }
    public int GetArmor() { return Armor; }
    public int GetMagicResist() { return MagicResist; }
    public int GetDmg() { return Dmg; }
    public int GetMagicDmg() { return MagicDmg; }
    public Skills[] GetSkills() { return skillSet; }

    public void SetHP(int newHP) { Hp = newHP; }
    public void SetSpeed(float newSpeed) { Speed = newSpeed; }
    public void SetArmor(int newArmor) { Armor = newArmor; }
    public void SetMagicResist(int newMR) { MagicResist = newMR; }
    public void SetDmg(int newDmg) { Dmg = newDmg; }
    public void SetMagicDmg(int newMDMG) { MagicDmg = newMDMG; }

    public bool GetActive() { return active; }

    public void ReduceHP(int damage)
    {
        if((damage - Armor) > 0)
        Hp -= (damage-Armor);
    }

}

[System.Serializable]
public struct Skills
{
    public string skillName;
    public Sprite skillIcon;
    public float skillCost;
    public string skillDesc;
}
