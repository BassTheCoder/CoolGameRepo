using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePlayer : MonoBehaviour
{
    public Vector3 StartingPosition = default;

    private GameObject _player = default;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
        {
            _player.transform.position = StartingPosition;
            GameObject.FindGameObjectWithTag("UI_HpBar").transform.GetChild(0).GetComponent<UI_HpBarScript>().Entity = _player;
        }
    }
}
