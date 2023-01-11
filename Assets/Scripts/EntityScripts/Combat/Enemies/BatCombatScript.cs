public class BatCombatScript : EnemyCombatScript
{
    void Start()
    {
        SetStats(
            maxHp: 50,
            attackPower: 5,
            defense: 0,
            critChancePercent: 0
            );
    }
}
