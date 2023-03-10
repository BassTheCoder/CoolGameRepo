using UnityEngine;

public class RewardButtonScript : MonoBehaviour
{
    public string StatToUpgrade;
    public int UpgradeValue;

    public void UpgradePlayer()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        player.UpgradeStat(StatToUpgrade, UpgradeValue);
    }

    public void DeactivateRewardsPanel()
    {
        GameObject.FindGameObjectWithTag("UI_Rewards").SetActive(false);
    }
}
