using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : State
{
    // [SerializeField] public State IdleState;
    private float previousGravityScale;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.climb);
        previousGravityScale = agent.rb2d.gravityScale;
        agent.rb2d.gravityScale = 0;
        agent.rb2d.velocity = Vector2.zero;
    }

    protected override void ExitState()
    {
        agent.rb2d.gravityScale = previousGravityScale;
        agent.animationManager.StartAnimation();
    }

    public override void StateUpdate()
    {
        if (agent.agentInput.MovementVector.magnitude > 0)
        {
            agent.animationManager.StartAnimation();
            agent.rb2d.velocity = new Vector2(
                agent.agentInput.MovementVector.x * agent.agentDataSO.climbHorizontalSpeed,
                agent.agentInput.MovementVector.y * agent.agentDataSO.climbVecticalSpeed
                );
        }
        else
        {
            agent.animationManager.StopAnimation();
            agent.rb2d.velocity = Vector2.zero;
        }

        if (!agent.climbingDetector.CanClimb)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
    }

    protected override void HandleAttack()
    {
        //prevent attack
    }

    protected override void HandleJumpPressed()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Jump));
    }
}
