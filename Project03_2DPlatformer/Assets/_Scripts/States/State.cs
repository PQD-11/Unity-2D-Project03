using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected State jumpState;
    protected Agent agent;

    public UnityEvent OnEnter, OnExit;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        agent.playerInput.OnAttack += HandleAttack;
        agent.playerInput.OnJumpPressed += HandleJumpPressed;
        agent.playerInput.OnJumpReleased += HandleJumpReleased;
        agent.playerInput.OnMovement += HandleMovement;
        // agent.playerInput.OnWeaponChange += HandleWeaponChange;
        OnEnter?.Invoke();
        EnterState();
    }

    protected virtual void EnterState()
    {

    }

    protected virtual void HandleMovement(Vector2 vector)
    {

    }

    protected virtual void HandleJumpReleased()
    {

    }

    protected virtual void HandleJumpPressed()
    {
        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(jumpState);
        }
    }

    protected virtual void HandleAttack()
    {

    }
    public virtual void StateUpdate()
    {

    }

    public virtual void StateFixedUpdate()
    {

    }

    public void Exit()
    {
        agent.playerInput.OnAttack -= HandleAttack;
        agent.playerInput.OnJumpPressed -= HandleJumpPressed;
        agent.playerInput.OnJumpReleased -= HandleJumpReleased;
        agent.playerInput.OnMovement -= HandleMovement;
        // agent.playerInput.OnWeaponChange += HandleWeaponChange;
        OnExit?.Invoke();
        ExitState();
    }
    protected virtual void ExitState()
    {

    }
}
