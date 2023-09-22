using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class IdleState : State
{
    // public State MoveState, ClimbState;
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.idle);
        if (agent.groundDetector.isGrounded)
        {
            agent.rb2d.velocity = Vector2.zero;
        }
    }

    public override void StateUpdate()
    {
        if (!agent.groundDetector.isGrounded)
        {
            return;
        }

        if (agent.climbingDetector.CanClimb && Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Climbing));
        }
        else if (Mathf.Abs(agent.agentInput.MovementVector.x) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Move));
        }
    }

    protected override void HandleMovement(Vector2 vector)
    {
        if (agent.climbingDetector.CanClimb && Mathf.Abs(vector.y) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Climbing));
        }
        else if (Mathf.Abs(vector.x) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Move));
        }
    }
}

