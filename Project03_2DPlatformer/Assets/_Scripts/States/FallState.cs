using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : MovementState
{
    [SerializeField] public State ClimbState;
    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.fall);

    }
    protected override void HandleJumpPressed()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.fall);
    }

    public override void StateUpdate()
    {
        movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y += agent.agentDataSO.gravityModifier * Physics2D.gravity.y * Time.deltaTime;
        agent.rb2d.velocity = movementData.currentVelocity;

        CalculateVelocity();
        SetPlayerVelocity();

        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(IdleState);
        }
        else if (agent.climbingDetector.CanClimb && Mathf.Abs(agent.playerInput.MovementVector.y) > 0)
        {
            agent.TransitionToState(ClimbState);
        }
    }
}
