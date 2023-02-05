using UnityEngine;

public class PlayerCombatScript : CombatBase
{
    public Animator EntityAnimator = default;
    public int ActiveWeapon = 1;

    private bool _isPlayerAttacking = false;
    private bool _hasAlreadyDied = false;

    void Start()
    {
        GetStats();
        SetActiveWeaponForAnimator();
    }

    void Update()
    {
        if (!IsAlive() && !_hasAlreadyDied)
        {
            Die();
        }
        else if (_hasAlreadyDied)
        {
            return;
        }

        if (WeaponSwitchPressed())
        {
            SwitchWeapon();
        }

        if (CanPlayerAttack() && Input.GetKeyDown(Keybinds.AttackMelee))
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

    protected override void GetStats()
    {
        Stats = gameObject.GetComponent<PlayerStats>();
    }

    private bool CanPlayerAttack()
    {
        var rewards = GameObject.FindGameObjectWithTag("UI_Rewards");

        return 
            !_isPlayerAttacking &&
            (rewards == null || !rewards.activeSelf);
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
        var uiWeaponsScript = GameObject.FindGameObjectWithTag("UI_Weapons").GetComponent<UI_WeaponScript>();
        if (ActiveWeapon == 1)
        {
            uiWeaponsScript.ActivateSwordUi();
        }
        else if (ActiveWeapon == 2)
        {
            uiWeaponsScript.ActivateAxeUi();
        }
        else if (ActiveWeapon == 3)
        {
            uiWeaponsScript.ActivateHammerUi();
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

    protected override void Die()
    {
        _hasAlreadyDied = true;
        SceneSwapperScript.LoadFailScene();
    }
}
