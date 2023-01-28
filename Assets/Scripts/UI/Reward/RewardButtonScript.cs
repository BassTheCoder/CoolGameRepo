using UnityEngine;

public class RewardButtonScript : MonoBehaviour
{
    public string StatToUpgrade;
    public int UpgradeValue;

    public void UpgradePlayer()
    {
        var playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();

        //if (player != null)
        //{
        //    player.GetComponent<Stats>().UpdateStatByFieldName<int>(StatToUpgrade, UpgradeValue);
        //}

        //monstrosity...
        if (StatToUpgrade == "MaxHP")
        {
            playerStats.MaxHP += UpgradeValue;
        }
        else if (StatToUpgrade == "CurrentHP")
        {
            playerStats.CurrentHP += UpgradeValue;
        }
        else if (StatToUpgrade == "AttackPower")
        {
            playerStats.AttackPower += UpgradeValue;
        }
        else if (StatToUpgrade == "ShootingPower")
        {
            playerStats.ShootingPower += UpgradeValue;
        }
        else if (StatToUpgrade == "MaxAmmo")
        {
            playerStats.MaxAmmo += UpgradeValue;
        }
        else if (StatToUpgrade == "CritChancePercent")
        {
            playerStats.CritChancePercent += UpgradeValue;
        }
        else if (StatToUpgrade == "Defense")
        {
            playerStats.Defense += UpgradeValue;
        }
    }

    
}
