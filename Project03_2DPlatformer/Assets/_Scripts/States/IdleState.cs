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

