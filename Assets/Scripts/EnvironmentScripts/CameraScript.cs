using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform _playerPosition;

    public bool MoveWithCursorExtension = true;
    public float CameraMovementDeadzone = 0.1f;

    private void Start()
    {
        GetPlayerPosition();
    }

    void Update()
    {
        if (_playerPosition == null)
        {
            GetPlayerPosition();
        }
        else
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
    }

    private void GetPlayerPosition()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerPosition = player.transform;
        }
    }

    private void Movement_Classic()
    {
        var deltaVector = Vector3.zero;
        float deltaX = _playerPosition.position.x - transform.position.x;
        if (deltaX > CameraMovementDeadzone || deltaX < -CameraMovementDeadzone)
        {
            deltaVector.x = transform.position.x < _playerPosition.position.x ? deltaX - CameraMovementDeadzone : deltaX + CameraMovementDeadzone;
        }
        float deltaY = _playerPosition.position.y - transform.position.y;
        if (deltaY > CameraMovementDeadzone || deltaY < -CameraMovementDeadzone)
        {
            deltaVector.y = transform.position.y < _playerPosition.position.y ? deltaY - CameraMovementDeadzone : deltaY + CameraMovementDeadzone;
        }

        transform.position += new Vector3(deltaVector.x, deltaVector.y, 0);
    }

    private void Movement_WithCursorExtension()
    {
        var vector = GetVectorFromPlayerToMouse();
        transform.position = _playerPosition.position + new Vector3(vector.x, vector.y, -1);
    }

    private Vector3 GetVectorFromPlayerToMouse() //todo: make it prettier
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _playerPosition.position.z));
        var direction = (mousePosition - _playerPosition.position).normalized;
        var distance = direction.magnitude;
        var vector = direction / distance;

        return vector/4;
    }
}
