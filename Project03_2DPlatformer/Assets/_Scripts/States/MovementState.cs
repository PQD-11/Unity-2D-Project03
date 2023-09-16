using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementState : State
{
    [SerializeField]
    protected MovementData movementData;
    // public State IdleState;

    public UnityEvent OnStep;

    private void Awake()
    {
        movementData = GetComponentInParent<MovementData>();
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.run);
        agent.animationManager.OnAnimationAction.AddListener(() => OnStep?.Invoke());

        movementData.horizontalMovementDirection = 0;
        movementData.currentSpeed = 0;
        movementData.currentVelocity = Vector2.zero;
    }

    public override void StateUpdate()
    {

        CalculateVelocity();
        SetPlayerVelocity();
        if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        }
    }

    protected void SetPlayerVelocity()
    {
        agent.rb2d.velocity = movementData.currentVelocity;

        // if ((this is JumpState) || (this is FallState))
        // {
        //     Debug.Log("Jump");
        //     agent.rb2d.velocity = new Vector2(movementData.currentVelocity.x * 0.75f, movementData.currentVelocity.y);
        // }
        // else
        // {
        //     agent.rb2d.velocity = movementData.currentVelocity;
        // }
    }

    protected void CalculateVelocity()
    {
        CalculateSpeed(agent.agentInput.MovementVector, movementData);
        CalculateHorizontalDirection(movementData);
        movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
        movementData.currentVelocity.y = agent.rb2d.velocity.y;
    }

    protected void CalculateSpeed(Vector2 movementVector, MovementData movementData)
    {
        if (Mathf.Abs(movementVector.x) > 0)
        {
            movementData.currentSpeed += agent.agentDataSO.acceleration * Time.deltaTime;
        }
        else
        {
            movementData.currentSpeed -= agent.agentDataSO.deacceleration * Time.deltaTime;
        }
        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, agent.agentDataSO.maxSpeed);
    }

    protected void CalculateHorizontalDirection(MovementData movementData)
    {
        if (agent.agentInput.MovementVector.x > 0)
        {
            movementData.horizontalMovementDirection = 1;
        }
        else if (agent.agentInput.MovementVector.x < 0)
        {
            movementData.horizontalMovementDirection = -1;
        }
    }

    protected override void ExitState()
    {
        agent.animationManager.ResetEvents();
    }
}
