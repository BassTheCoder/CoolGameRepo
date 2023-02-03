using System.Linq;
using UnityEngine;

public class PlayerMovementScript : EntityMovementScript
{

    private bool _canDash = true;
    private bool _isDashing = false;
    private Vector3 _dashingVector = default;
    private float _dashDuration = 0.13f;
    private float _dashStopTime = 0f;
    private float _dashDistance = 3.5f;
    private float _dashCooldown = 1f;
    private float NextDashTime = 0f;

    public float DashCooldownDelta = 0f;

    private void Start()
    {
        GetPhysicsProperties();
    }

    void FixedUpdate()
    {
        if (_isDashing)
        {
            Move(_dashingVector);
            UpdateDashStatus();
        }
        else
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");

            GetMoveVector(xAxis, yAxis);
            Move(MoveVector);
        }
    }

    private void Update()
    {
        GetDashCooldownDelta();
        if (Input.GetKeyDown(Keybinds.Dash) && CanDash() && !_isDashing)
        {
            Dash();
        }
    }

    private void Dash()
    {
        _isDashing = true;
        EntityAnimator.SetBool("IsPlayerDashing", true);
        _canDash = false;
        _dashingVector = MoveVector * _dashDistance;
        _dashStopTime = Time.time + _dashDuration;
        NextDashTime = Time.time + _dashCooldown;
        DashCooldownDelta = _dashCooldown;
    }

    private bool CanDash()
    {
        return Time.time >= NextDashTime && _canDash;
    }

    private void UpdateDashStatus()
    {
        if (Time.time >= _dashStopTime)
        {
            _isDashing = false;
            EntityAnimator.SetBool("IsPlayerDashing", false);
            _canDash = true;
        }
    }

    private void GetDashCooldownDelta()
    {
        var result = NextDashTime - Time.time;
        
        DashCooldownDelta = result > 0 ? result : 0;
    }
}
