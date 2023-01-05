using UnityEngine;

public class ElementalMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();

        IsModelReversed = true;
        MovementSpeedMultiplier = 0.5f;
    }
}
