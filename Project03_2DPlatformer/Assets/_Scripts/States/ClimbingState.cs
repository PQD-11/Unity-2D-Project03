using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : State
{
    [SerializeField] public State IdleState;
    private float previousGravityScale;

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.climb);
        previousGravityScale = agent.rb2d.gravityScale;
        agent.rb2d.gravityScale = 0;
        agent.rb2d.velocity = Vector2.zero;
    }

    protected override void ExitState()
    {
        agent.rb2d.gravityScale = previousGravityScale;
        agent.agentAnimation.StartAnimation();
    }

    public override void StateUpdate()
    {
        if (agent.playerInput.MovementVector.magnitude > 0)
        {
            agent.agentAnimation.StartAnimation();
            agent.rb2d.velocity = new Vector2(
                agent.playerInput.MovementVector.x * agent.agentDataSO.climbHorizontalSpeed,
                agent.playerInput.MovementVector.y * agent.agentDataSO.climbVecticalSpeed
                );
        }
        else
        {
            agent.agentAnimation.StopAnimation();
            agent.rb2d.velocity = Vector2.zero;
        }

        if (!agent.climbingDetector.CanClimb)
        {
            agent.TransitionToState(IdleState);
        }
    }

    protected override void HandleJumpPressed()
    {
        agent.TransitionToState(JumpState);
    }
}
