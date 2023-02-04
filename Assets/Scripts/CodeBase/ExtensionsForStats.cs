using UnityEngine;

public static class ExtensionsForStats
{
    public static void SetStats(this GameObject combatGameObject, EntityStats stats)
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

    public static int GetCurrentHp(this GameObject entity)
    {
        return entity.GetComponent<EntityStats>().CurrentHP;
    }

    public static int GetCurrentHpPercent(this GameObject entity)
    {
        return Mathf.FloorToInt(entity.GetCurrentHpDecimal() * 100);
    }

    public static float GetCurrentHpDecimal(this GameObject entity)
    {
        var stats = entity.GetComponent<EntityStats>();
        if (stats != null)
        {
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
            Debug.Log($"{entity.name} does not have Stats component.");
            return 0;
        }
    }

    public static void UpgradeStat(this GameObject player, string StatToUpgrade, int UpgradeValue)
    {
        if (!player.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }

        if (StatToUpgrade == "MaxHP")
        {
            player.UpdateMaxHpBy(UpgradeValue);
        }
        else if (StatToUpgrade == "CurrentHP")
        {
            player.HealFor(UpgradeValue);
        }
        else if (StatToUpgrade == "AttackPower")
        {
            player.UpdateAttackPowerBy(UpgradeValue);
        }
        else if (StatToUpgrade == "AxeAttackPower")
        {
            player.UpdateAxeAttackPowerBy(UpgradeValue);
        }
        else if (StatToUpgrade == "HammerAttackPower")
        {
            player.UpdateHammerAttackPowerBy(UpgradeValue);
        }
        else if (StatToUpgrade == "ShootingPower")
        {
            player.UpdateShootingPowerBy(UpgradeValue);
        }
        else if (StatToUpgrade == "Piercing")
        {
            player.UpdatePiercingBy(UpgradeValue);
        }
        else if (StatToUpgrade == "MaxAmmo")
        {
            player.UpdateMaxAmmoBy(UpgradeValue);
        }
        else if (StatToUpgrade == "CritChancePercent")
        {
            player.UpdateCritChanceBy(UpgradeValue);
        }
        else if (StatToUpgrade == "Defense")
        {
            player.UpdateDefenseBy(UpgradeValue);
        }
        else if (StatToUpgrade == "MovementSpeed")
        {
            player.UpdateMovementSpeedBy(UpgradeValue);
        }
    }

    public static void UpdateMaxHpBy(this GameObject entity, int amount)
    {
        entity.GetComponent<EntityStats>().MaxHP += amount;        
        entity.GetComponent<EntityStats>().CurrentHP += amount;
    }

    public static void HealFor(this GameObject entity, int amount)
    {
        var stats = entity.GetComponent<EntityStats>();
        stats.CurrentHP += amount;
        if (stats.CurrentHP > stats.MaxHP)
        {
            stats.CurrentHP = stats.MaxHP;
        }
    }

    public static void DamageFor(this GameObject entity, int amount)
    {
        var damage = GetDamageRegardingDefense(amount);

        entity.GetComponent<EntityStats>().CurrentHP -= damage;

        int GetDamageRegardingDefense(int damage)
        {
            var damageRegardingDefense = damage * GetDefenseAsDamageMultiplier();
            var finalDamage = Mathf.FloorToInt(damageRegardingDefense);
            if (finalDamage < 1)
            {
                finalDamage = 1;
            }
            return finalDamage;
        }

        float GetDefenseAsDamageMultiplier()
        {
            var defense = entity.GetComponent<EntityStats>().Defense;
            return 1 - (float)defense / 100;
        }
    }

    public static void UpdateAttackPowerBy(this GameObject entity, int amount)
    {
        entity.GetComponent<EntityStats>().AttackPower += amount;
    }

    public static void UpdateDefenseBy(this GameObject entity, int amount)
    {
        entity.GetComponent<EntityStats>().Defense += amount;
    }

    public static void UpdateMovementSpeedBy(this GameObject entity, float amount)
    {
        amount /= 10;
        entity.GetComponent<EntityStats>().MovementSpeed += amount;
    }

    public static void UpdateAxeAttackPowerBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().AxeAttackPower += amount;
    }

    public static void UpdateHammerAttackPowerBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().HammerAttackPower += amount;
    }

    public static void UpdateShootingPowerBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().ShootingPower += amount;
    }

    public static void UpdatePiercingBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().ArrowPiercing += amount;
    }

    public static void UpdateAmmoBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }

        var playerStats = entity.GetComponent<PlayerStats>();
        playerStats.Ammo += amount;

        if (playerStats.Ammo > playerStats.MaxAmmo)
        {
            entity.GetComponent<PlayerStats>().Ammo = playerStats.MaxAmmo;
        }

    }

    public static void RefillAmmo(this GameObject entity)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().Ammo = entity.GetComponent<PlayerStats>().MaxAmmo;
    }

    public static void UpdateMaxAmmoBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().MaxAmmo += amount;
    }

    public static void UpdateCritChanceBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().CritChancePercent += amount;
    }

    public static void UpdateCritDamageMultiplierBy(this GameObject entity, int amount)
    {
        if (!entity.CompareTag("Player"))
        {
            Debug.Log("This method is for player object only.");
            return;
        }
        entity.GetComponent<PlayerStats>().CritDamageMultiplier += amount;
    }
}
