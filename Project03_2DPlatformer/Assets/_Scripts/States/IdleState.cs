using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public State MoveState;
    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.idle);
    }

    protected override void HandleMovement(Vector2 vector)
    {
        if (Mathf.Abs(vector.x) > 0)
        {
            agent.TransitionToState(MoveState);
        }
    }
}

