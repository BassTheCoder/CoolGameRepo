using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class StatsListScript : MonoBehaviour
{
    private PlayerStats _stats;
    
    void Start()
    {
        _stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        SendStatValuesToView();
    }

    private void SendStatValuesToView()
    {
        StringBuilder statValues = new();

        statValues.AppendLine($"{_stats.CurrentHP}");
        statValues.AppendLine($"{_stats.Defense}");
        statValues.AppendLine($"{_stats.AttackPower}");
        statValues.AppendLine($"{_stats.AxeAttackPower}");
        statValues.AppendLine($"{_stats.HammerAttackPower}");
        statValues.AppendLine($"{_stats.ShootingPower}");
        statValues.AppendLine($"{_stats.MaxAmmo}");
        statValues.AppendLine($"{_stats.ArrowPiercing}");
        statValues.AppendLine($"{_stats.CritChancePercent}%");

        GetComponent<TextMeshProUGUI>().text = statValues.ToString();
    }
}
