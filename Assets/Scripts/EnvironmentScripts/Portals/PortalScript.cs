using UnityEngine;

public class PortalScript : MonoBehaviour
{
    protected bool IsCollidingWithPlayer = false;
    protected BoxCollider2D BoxCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsCollidingWithPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsCollidingWithPlayer = false;
    }
}
