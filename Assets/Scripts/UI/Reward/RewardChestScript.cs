using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PossibleRewards))]
public class RewardChestScript : MonoBehaviour
{
    public Animator RewardChestAnimator;
    public bool IsLooted = false;
    public List<Reward> Rewards;

    private PossibleRewards _possibleRewards;
    private bool _isCollidingWithPlayer = false;

    void Start()
    {

        Rewards = new List<Reward>();
        _possibleRewards = GetComponent<PossibleRewards>();
        GetRewards();
        AssignRewardTexts();
        Debug.Log($"{Rewards.Count} rewards drawn. {string.Join($", ", Rewards.Select(reward => $"{reward.StatToUpgrade} + {reward.UpgradeValue}"))}");
    }

    void Update()
    {
        if (Input.GetKeyDown(Keybinds.Interact) && !IsLooted && _isCollidingWithPlayer)
        {
            IsLooted = true;
        }
        if (RewardChestAnimator != null)
        {
            RewardChestAnimator.SetBool("IsLooted", IsLooted);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isCollidingWithPlayer = false;
        }
    }

    private void GetRewards()
    {
        var possibleRewards = _possibleRewards.RewardsPool;
        if (possibleRewards == null || possibleRewards.Count < 1)
        {
            Debug.Log("There's no rewards to choose from. Chest remains empty.");
        }
        else
        {
            var random = new System.Random();
            for (int i = 0; i < 3; i++)
            {
                var randomIndex = random.Next(0, possibleRewards.Count - 1);
                Rewards.Add(possibleRewards[randomIndex]);
                possibleRewards.RemoveAt(randomIndex);
            }
        }
    }

    private void AssignRewardTexts()
    {
        foreach (var reward in Rewards)
        {
            if (reward.StatToUpgrade == "MaxHP")
            {
                reward.UpgradeText = $"MAX HP\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "CurrentHP")
            {
                reward.UpgradeText = $"HEAL\nFOR\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "AttackPower")
            {
                reward.UpgradeText = $"SWORD DMG\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "AxeAttackPower")
            {
                reward.UpgradeText = $"AXE DMG\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "HammerAttackPower")
            {
                reward.UpgradeText = $"HAMMER DMG\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "Piercing")
            {
                reward.UpgradeText = $"PIERCING\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "ShootingPower")
            {
                reward.UpgradeText = $"SHOOTING DMG\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "MaxAmmo")
            {
                reward.UpgradeText = $"MAX AMMO\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "CritChancePercent")
            {
                reward.UpgradeText = $"CRIT CHANCE\n+\n{reward.UpgradeValue} %";
            }
            else if (reward.StatToUpgrade == "Defense")
            {
                reward.UpgradeText = $"DEFENSE\n+\n{reward.UpgradeValue}";
            }
            else if (reward.StatToUpgrade == "MovementSpeed")
            {
                reward.UpgradeText = $"SPEED\n+\n{reward.UpgradeValue}";
            }
        }
    }
}
