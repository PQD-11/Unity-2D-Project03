using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class JumpState : MovementState
{
    [SerializeField] public State ClimbState;
    private bool jumpPressed;
    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.jump);
        // movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y = agent.agentDataSO.jumpForce;
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
        else if (agent.climbingDetector.CanClimb && Mathf.Abs(agent.playerInput.MovementVector.y) > 0)
        {
            agent.TransitionToState(ClimbState);
        }
    }

    private void ControlJumpHeight()
    {
        if (!jumpPressed)
        {
            movementData.currentVelocity = agent.rb2d.velocity;
            movementData.currentVelocity.y += agent.agentDataSO.lowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
            movementData.currentVelocity.x = movementData.currentVelocity.x / 2;
            agent.rb2d.velocity = movementData.currentVelocity;
        }
    }
}
