using UnityEngine;

public class BelcherMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();

        IsModelReversed = true;
        MovementSpeedMultiplier = 0.3f;
    }
}
