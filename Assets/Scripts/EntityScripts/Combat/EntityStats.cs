using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public bool OverrideDefaultStats = true;

    public int MaxHP = 100;
    public int CurrentHP = 100;
    public int AttackPower = 10;
    public int Defense = 0;
    public float MovementSpeed = 0.7f;
}
