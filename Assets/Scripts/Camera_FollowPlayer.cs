using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour
{
    public Transform PlayerPosition;

    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, PlayerPosition.position.z));
        var direction = mousePosition - PlayerPosition.position;
        direction.Normalize();
        var distance = direction.magnitude;
        var vector = direction/distance;
        transform.position = PlayerPosition.position + new Vector3(vector.x/3, vector.y/3, -1);
    }
}
