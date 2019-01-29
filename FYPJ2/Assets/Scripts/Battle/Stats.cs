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

    private bool active = true;

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
    public void SetArmor(int newArmor) { Hp = newArmor; }
    public void SetMagicResist(int newMR) { Hp = newMR; }
    public void SetDmg(int newDmg) { Hp = newDmg; }
    public void SetMagicDmg(int newMDMG) { Hp = newMDMG; }

    public void ReduceHP(int damage) { Hp -= damage; }

}

[System.Serializable]
public struct Skills
{
    public string skillName;
    public Sprite skillIcon;
    public float skillCost;
    public string skillDesc;
}
