using UnityEngine;

public class BelcherMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();
    }
}
