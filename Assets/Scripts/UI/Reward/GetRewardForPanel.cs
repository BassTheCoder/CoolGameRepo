using TMPro;
using UnityEngine;

public class GetRewardForPanel : MonoBehaviour
{
    public int RewardNumber = 0;

    private int _rewardPoolIndex;
    void Start()
    {
        _rewardPoolIndex = RewardNumber - 1;
        var rewardChest = GameObject.FindGameObjectWithTag("RewardChest");
        if (rewardChest != null)
        {
            var reward = rewardChest.GetComponent<RewardChestScript>().Rewards[_rewardPoolIndex];

            if (reward != null)
            {
                transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = reward.UpgradeText;
                transform.GetChild(1).GetComponent<RewardButtonScript>().StatToUpgrade = reward.StatToUpgrade;
                transform.GetChild(1).GetComponent<RewardButtonScript>().UpgradeValue = reward.UpgradeValue;
            }
        }
    }
}
