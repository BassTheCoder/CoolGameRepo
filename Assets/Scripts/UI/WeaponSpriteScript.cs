using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpriteScript : MonoBehaviour
{
    public Sprite ActiveWeaponSprite;
    public Sprite InactiveWeaponSprite;

    public void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = ActiveWeaponSprite;
    }

    public void Deactivate()
    {
        GetComponent<SpriteRenderer>().sprite = InactiveWeaponSprite;
    }
}
