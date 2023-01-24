using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardChoiceScript : MonoBehaviour
{
    private GameObject _rewardChest = null;
    private bool _shouldShowRewards = false;
    private bool _isShowingRewards = false;


    private void Update()
    {
        if (IsChestSpawned()) 
        {
            _rewardChest = GameObject.FindGameObjectWithTag("RewardChest");
            CheckIfShouldShowRewards();
            if (_shouldShowRewards)
            {
                ShowRewards();
            }
        }
    }

    private void CheckIfShouldShowRewards()
    {
        _shouldShowRewards =
            _rewardChest.GetComponent<RewardChestScript>().IsLooted &&
           !_isShowingRewards;
    }

    private void ShowRewards()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        _isShowingRewards = true;
    }

    private bool IsChestSpawned()
    {
        return GameObject.FindGameObjectWithTag("RewardChest") != null;
    }
}
