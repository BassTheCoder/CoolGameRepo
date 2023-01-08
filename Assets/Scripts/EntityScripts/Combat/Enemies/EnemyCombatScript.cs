using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatScript : CombatBase
{
    void Start()
    {
        GetStats();
    }

    void Update()
    {
        if (!IsAlive())
        {
            Die();
        }

        var currentHpPercent = GetCurrentHpPercent();
        if (currentHpPercent < 100)
        {
            ActivateHpBar();
        }
        else
        {
            DeactivateHpBar();
        }
    }

    public void Damage(int damage)
    {
        GetHitFor(damage);
    }

    private void ActivateHpBar()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
    }

    private void DeactivateHpBar()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
