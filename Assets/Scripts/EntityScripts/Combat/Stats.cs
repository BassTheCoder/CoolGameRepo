using UnityEngine;

public class Stats : MonoBehaviour
{
    public bool OverrideDefaultStats = true;

    public int MaxHP = 100;
    public int CurrentHP = 100;
    public int AttackPower = 10;
    public int ShootingPower = 3;
    public int Ammo = 10;
    public int MaxAmmo = 10;
    public float AttackSpeed = 0.3f;
    public int CritChancePercent = 0;
    public int CritDamageMultiplier = 2;
    public int Defense = 0;
}
