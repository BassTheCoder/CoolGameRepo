using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatsScript : MonoBehaviour
{
    private bool _areStatsOnScreen = false;

    void Update()
    {
        if (AreRewardsOnScreen() && _areStatsOnScreen)
        {
            transform.GetChild(3).gameObject.SetActive(false);
            _areStatsOnScreen = false;
        }
        else if (Input.GetKeyDown(Keybinds.Stats) && !AreRewardsOnScreen())
        {
            transform.GetChild(3).gameObject.SetActive(!_areStatsOnScreen);
            _areStatsOnScreen = !_areStatsOnScreen;
        }
    }

    private bool AreRewardsOnScreen()
    {
        return GameObject.FindGameObjectWithTag("UI_Rewards") != null;
    }
}
