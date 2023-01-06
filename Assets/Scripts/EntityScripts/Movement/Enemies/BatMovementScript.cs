using UnityEngine;

public class BatMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();

        MovementSpeedMultiplier = 0.8f;
    }
}
