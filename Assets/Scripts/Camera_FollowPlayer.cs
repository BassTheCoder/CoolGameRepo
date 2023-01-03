using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour
{
    public Transform PlayerPosition;

    void Update()
    {
        transform.position = PlayerPosition.position + new Vector3(0,0,-1);
    }
}
