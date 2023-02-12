using System.Text;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class StatsListScript : MonoBehaviour
{
    public PlayerStats Stats;
    public bool EndGameScreen = false;

    void Start()
    {
        if (EndGameScreen)
        {
            Stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<InitializePlayer>().Stats;
        }
        else
        {
            Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
    }

    private void Update()
    {
        SendStatValuesToView();
    }

    private void SendStatValuesToView()
    {
        StringBuilder statValues = new();

        statValues.AppendLine($"{Stats.CurrentHP}/{Stats.MaxHP}");
        statValues.AppendLine($"{Stats.Defense}%");
        statValues.AppendLine($"{Stats.MovementSpeed * 10}");
        statValues.AppendLine($"{Stats.AttackPower}");
        statValues.AppendLine($"{Stats.AxeAttackPower}");
        statValues.AppendLine($"{Stats.HammerAttackPower}");
        statValues.AppendLine($"{Stats.ShootingPower}");
        statValues.AppendLine($"{Stats.MaxAmmo}");
        statValues.AppendLine($"{Stats.ArrowPiercing}");
        statValues.AppendLine($"{Stats.CritChancePercent}%");

        GetComponent<TextMeshProUGUI>().text = statValues.ToString();
    }
}
