using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour
{
    public Transform PlayerPosition;

    public bool MoveWithCursorExtension = true;
    public float CameraMovementDeadzone_X = 0.15f;
    public float CameraMovementDeadzone_Y = 0.15f;

    void Update()
    {
        if (MoveWithCursorExtension)
        {
            Movement_WithCursorExtension();
        }
        else
        {
            Movement_Classic();
        }
    }

    private void Movement_Classic()
    {
        var deltaVector = Vector3.zero;
        float deltaX = PlayerPosition.position.x - transform.position.x;
        if (deltaX > CameraMovementDeadzone_X || deltaX < -CameraMovementDeadzone_X)
        {
            deltaVector.x = transform.position.x < PlayerPosition.position.x ? deltaX - CameraMovementDeadzone_X : deltaX + CameraMovementDeadzone_X;
        }
        float deltaY = PlayerPosition.position.y - transform.position.y;
        if (deltaY > CameraMovementDeadzone_Y || deltaY < -CameraMovementDeadzone_Y)
        {
            deltaVector.y = transform.position.y < PlayerPosition.position.y ? deltaY - CameraMovementDeadzone_Y : deltaY + CameraMovementDeadzone_Y;
        }

        transform.position += new Vector3(deltaVector.x, deltaVector.y, 0);
    }

    private void Movement_WithCursorExtension()
    {
        var vector = GetVectorFromPlayerToMouse();
        transform.position = PlayerPosition.position + new Vector3(vector.x, vector.y, -1);
    }

    private Vector3 GetVectorFromPlayerToMouse() //todo: make it prettier
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, PlayerPosition.position.z));
        var direction = mousePosition - PlayerPosition.position;
        direction.Normalize();
        var distance = direction.magnitude;
        var vector = direction / distance;

        return vector/4;
    }
}
