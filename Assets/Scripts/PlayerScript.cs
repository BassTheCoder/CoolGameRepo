using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerScript : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Vector3 _moveDelta;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        //Reset move
        _moveDelta = new Vector3(xAxis, yAxis, 0);

        //sprite orientation based on movement
        if (_moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //move
        transform.Translate(_moveDelta * Time.deltaTime);
    }
}
