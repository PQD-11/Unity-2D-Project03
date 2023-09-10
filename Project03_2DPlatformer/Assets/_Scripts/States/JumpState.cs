using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class JumpState : MovementState
{
    public float jumpForce = 12;
    public float lowJumpMultiplier = 2;
    public State FallState;
    private bool jumpPressed;
    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.jump);
        // movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y = jumpForce;
        agent.rb2d.velocity = movementData.currentVelocity;
        jumpPressed = true;
    }

    protected override void HandleJumpPressed()
    {
        jumpPressed = true;
    }

    protected override void HandleJumpReleased()
    {
        jumpPressed = false;
    }

    public override void StateUpdate()
    {
        ControlJumpHeight();
        CalculateVelocity();
        SetPlayerVelocity();
        if (agent.rb2d.velocity.y <= 0)
        {
            agent.TransitionToState(FallState);
        }
    }

    private void ControlJumpHeight()
    {
        if (!jumpPressed)
        {
            movementData.currentVelocity = agent.rb2d.velocity;
            movementData.currentVelocity.y += lowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
            agent.rb2d.velocity = movementData.currentVelocity;
        }
    }
}
