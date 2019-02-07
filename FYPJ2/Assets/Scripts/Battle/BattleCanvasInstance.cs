using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BattleCanvasInstance : MonoBehaviour {
    public static BattleCanvasInstance Instance;

    public GraphicRaycaster RayCaster;
    public EventSystem EventSystem;
    public GameObject RewardsScreen;
    public GameObject RewardItem;
    public Sprite[] RewardSprites;

    public bool CollectedReward = false;
    private GameObject RewardItemsList;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        RewardsScreen.SetActive(false);
        RewardItemsList = RewardsScreen.transform.GetChild(0).gameObject;
    }

    public void SetRewardItem(int rewardIndex, int rewardType, string itemCount)
    {
        RewardsScreen.SetActive(true);
        GameObject reward;
        if (RewardItemsList.transform.childCount > rewardIndex)
        {
            reward = RewardItemsList.transform.GetChild(rewardIndex).gameObject;
            reward.SetActive(true);
        }
        else
            reward = Instantiate(RewardItem, RewardItemsList.transform);

        reward.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemCount;
        if (RewardSprites.Length > 0)
        {

            switch (rewardType)
            {
                case 0:
                    reward.GetComponent<Image>().sprite = RewardSprites[0];
                    break;
            }
        }
    }

    public void RewardsCollected()
    {
        foreach(Transform child in RewardItemsList.transform)
        {
            child.gameObject.SetActive(false);
        }
        RewardsScreen.SetActive(false);
    }

    public void ConfirmReward()
    {
        CollectedReward = true;
        RewardsCollected();
        gameObject.SetActive(false);
        RewardsScreen.SetActive(false);
    }
}
