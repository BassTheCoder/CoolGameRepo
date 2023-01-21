using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform ShootPoint = default;

    private void Update()
    {
        if (Input.GetKeyDown(Keybinds.AttackRanged))
        {
            Shoot();
        }
    }

    void Shoot()
    {

    }
}
