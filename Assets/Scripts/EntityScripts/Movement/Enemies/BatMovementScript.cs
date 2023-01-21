public class BatMovementScript : EnemyMovementScript
{
    void Start()
    {
        GetPhysicsProperties();
        GetPlayerObjectTransform();
        DoNotFollowIfTheresNoPlayer();
    }
}
