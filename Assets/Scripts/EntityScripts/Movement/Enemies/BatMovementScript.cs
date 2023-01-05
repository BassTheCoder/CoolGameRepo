using UnityEngine;

public class BatMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();

        IsModelReversed = true;
        MovementSpeedMultiplier = 0.8f;
    }
}
