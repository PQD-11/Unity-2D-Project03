using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    [SerializeField]
    protected MovementData movementData;
    public State IdleState;
    public float acceleration, deacceleration, maxSpeed;
    private void Awake()
    {
        movementData = GetComponentInParent<MovementData>();
    }

    protected override void EnterState()
    {
        agent.agentAnimation.PlayAnimation(AnimationType.run);
        
        movementData.horizontalMovementDirection = 0;
        movementData.currentSpeed = 0;
        movementData.currentVelocity = Vector2.zero;
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        CalculateVelocity();
        SetPlayerVelocity();
        if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
        {
            agent.TransitionToState(IdleState);
        }
    }

    protected void SetPlayerVelocity()
    {
        agent.rb2d.velocity = movementData.currentVelocity;
    }

    protected void CalculateVelocity()
    {
        CalculateSpeed(agent.playerInput.MovementVector, movementData);
        CalculateHorizontalDirection(movementData);
        movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
        movementData.currentVelocity.y = agent.rb2d.velocity.y;
    }

    protected void CalculateSpeed(Vector2 movementVector, MovementData movementData)
    {
        if (Mathf.Abs(movementVector.x) > 0)
        {
            movementData.currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            movementData.currentSpeed -= deacceleration * Time.deltaTime;
        }
        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, maxSpeed);
    }

    protected void CalculateHorizontalDirection(MovementData movementData)
    {
        if (agent.playerInput.MovementVector.x > 0)
        {
            movementData.horizontalMovementDirection = 1;
        }
        else if (agent.playerInput.MovementVector.x < 0)
        {
            movementData.horizontalMovementDirection = -1;
        }
    }
}
