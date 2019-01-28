using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace CompleteProject
{
    public class WeaponButton : MonoBehaviour
    {

        public int weaponNumber;

        public PlayerVars player;

        public ShopObject shop;

        public TextMeshProUGUI name;
        public TextMeshProUGUI cost;
        public TextMeshProUGUI description;

        private AudioSource source;

        // Use this for initialization
        void Start()
        {
            source = GetComponent<AudioSource>();
            SetButton();

            //player = player.GetComponent<PlayerVars>();
        }

        void SetButton()
        {
            string costString = shop.ShopList[weaponNumber].cost.ToString();
            name.text = shop.ShopList[weaponNumber].name;
            cost.text = "$" + shop.ShopList[weaponNumber].cost;
            description.text = shop.ShopList[weaponNumber].description;
        }

        public void OnClick()
        {
            if (player.gold >= shop.ShopList[weaponNumber].cost)
            {

                player.gold -= shop.ShopList[weaponNumber].cost;

            }
            else
            {
                source.Play();
            }
        }

    }

}