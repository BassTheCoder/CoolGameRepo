using UnityEngine;

public class BelcherMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();

        MovementSpeedMultiplier = 0.3f;
    }
}
