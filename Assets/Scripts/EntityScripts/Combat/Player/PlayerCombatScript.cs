using UnityEngine;

public class PlayerCombatScript : CombatBase
{
    public Animator EntityAnimator = default;
    public int ActiveWeapon = 1;

    private bool _isPlayerAttacking = false;

    void Start()
    {
        GetStats();
        SetActiveWeaponForAnimator();
    }

    void Update()
    {
        if (!IsAlive())
        {
            Die();
        }

        if (WeaponSwitchPressed())
        {
            SwitchWeapon();
        }

        if (!_isPlayerAttacking && Input.GetKeyDown(Keybinds.AttackMelee))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (_isPlayerAttacking)
        {
            StopAttacking();
        }
    }

    private void Attack()
    {
        _isPlayerAttacking = true;
        SetAnimatorAttackingState(_isPlayerAttacking);
    }

    private void StopAttacking()
    {
        _isPlayerAttacking = false;
        SetAnimatorAttackingState(_isPlayerAttacking);
    }

    private void SetAnimatorAttackingState(bool attackingState)
    {
        if (EntityAnimator != null)
        {
            EntityAnimator.SetBool("IsPlayerAttacking", attackingState);
        }
    }

    private bool WeaponSwitchPressed()
    {
        if (Input.GetKeyDown(Keybinds.Weapon1))
        {
            ActiveWeapon = 1;
            return true;
        }
        else if (Input.GetKeyDown(Keybinds.Weapon2))
        {
            ActiveWeapon = 2;
            return true;
        }
        else if (Input.GetKeyDown(Keybinds.Weapon3))
        {
            ActiveWeapon = 3;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SwitchWeapon()
    {
        if (ActiveWeapon == 1)
        {
            GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<UI_WeaponSpriteScript>().Activate();
            GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
        }
        else if (ActiveWeapon == 2)
        {
            GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<UI_WeaponSpriteScript>().Activate();
            GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
        }
        else if (ActiveWeapon == 3)
        {
            GameObject.FindGameObjectWithTag("SwordSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("AxeSprite").GetComponent<UI_WeaponSpriteScript>().Deactivate();
            GameObject.FindGameObjectWithTag("HammerSprite").GetComponent<UI_WeaponSpriteScript>().Activate();
        }

        SetActiveWeaponForAnimator();
    }

    private void SetActiveWeaponForAnimator()
    {
        if (EntityAnimator != null)
        {
            EntityAnimator.SetInteger("ActiveWeapon", ActiveWeapon);
        }
    }
}
