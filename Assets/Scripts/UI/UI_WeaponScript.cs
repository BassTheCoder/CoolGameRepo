using UnityEngine;

public class UI_WeaponScript : MonoBehaviour
{
    public int ActiveWeapon = 0;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            ActiveWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatScript>().ActiveWeapon;
            UpdateUiWeapon();
        }
    }

    public void UpdateUiWeapon()
    {
        if (ActiveWeapon == 1)
        {
            ActivateSwordUi();
        }
        else if (ActiveWeapon == 2)
        {
            ActivateAxeUi();
        }
        else if (ActiveWeapon == 3)
        {
            ActivateHammerUi();
        }
    }

    public void ActivateSwordUi()
    {
        GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<UI_WeaponSpriteScript>().Activate();
        GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
        GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
    }

    public void ActivateAxeUi()
    {
        GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
        GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<UI_WeaponSpriteScript>().Activate();
        GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
    }

    public void ActivateHammerUi()
    {
        GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
        GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
        GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<UI_WeaponSpriteScript>().Activate();
    }
}
