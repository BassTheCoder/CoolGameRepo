public class BelcherCombatScript : EnemyCombatScript
{
    void Start()
    {
        SetStats(
            maxHp: 200,
            attackPower: 20,
            defense: 3,
            critChancePercent: 5
            );
    }
}
