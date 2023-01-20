using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Extensions
{
    public static void SetStats(this GameObject combatGameObject, Stats stats)
    {
        if (combatGameObject == null)
        {
            Debug.Log("Game object cannot be null.");
            return;
        }
        else if (stats == null)
        {
            Debug.Log("Given stats cannot be null.");
            return;
        }
        else if (!combatGameObject.TryGetComponent<CombatBase>(out _))
        {
            Debug.Log("Object must have a combat script.");
            return;
        }
        else
        {
            combatGameObject.GetComponent<CombatBase>().SetStats(stats);
        }
    }

    public static float GetPlayersCurrentHpPercent(this GameObject player)
    {
        if (player.CompareTag("Player"))
        {
            var stats = player.GetComponent<Stats>();
            var result = ((float)stats.CurrentHP / (float)stats.MaxHP);
            if (result > 1)
            {
                result = 1;
            }
            else if (result < 0)
            {
                result = 0;
            }
            return result;
        }
        else
        {
            Debug.Log("This method is supported for player object only.");
            return 0f;
        }
    }
}
