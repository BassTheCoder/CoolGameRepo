using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatScript : CombatBase
{
    private void Start()
    {
        GetStats();
    }

    public void Damage(int damage)
    {
        GetHitFor(damage);
    }
}
