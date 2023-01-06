using UnityEngine;

public class ElementalMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();

        MovementSpeedMultiplier = 0.5f;
    }
}
