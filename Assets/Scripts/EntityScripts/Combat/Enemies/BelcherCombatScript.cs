public class BelcherCombatScript : EnemyCombatScript
{
    void Start()
    {
        AttackDelayFrames = 200;

        SetStats(
            maxHp: 200,
            attackPower: 20,
            defense: 3,
            critChancePercent: 5
            );
    }
}
