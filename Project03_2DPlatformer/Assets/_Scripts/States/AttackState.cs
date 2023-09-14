using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    [SerializeField] protected State IdleState;
    public LayerMask hittableLayerMask;

    protected Vector2 direction;

    public UnityEvent<AudioClip> OnWeaponSound;
    private bool showGizmos;

    protected override void EnterState()
    {
        agent.animationManager.ResetEvents();
        agent.animationManager.PlayAnimation(AnimationType.attack);
        agent.animationManager.OnAnimationEnd.AddListener(TransitionToIdleState);
        agent.animationManager.OnAnimationAction.AddListener(PerformAttack);

        agent.agentWeaponManager.ToggleWeaponVisibility(true);
        direction = agent.transform.right * (agent.transform.localScale.x > 0 ? 1 : -1);

        if (agent.groundDetector.isGrounded)
        {
            agent.rb2d.velocity = Vector2.zero;
        }
    }

    private void PerformAttack()
    {
        OnWeaponSound?.Invoke(agent.agentWeaponManager.GetCurrentWeapon().weaponSwingSound);
        agent.animationManager.OnAnimationAction.RemoveListener(PerformAttack);
        agent.agentWeaponManager.GetCurrentWeapon().PerformAttack(agent, hittableLayerMask, direction);
    }

    private void TransitionToIdleState()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(TransitionToIdleState);

        if (agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(IdleState);
        }
        else
        {
            agent.TransitionToState(FallState);
        }
    }

    protected override void ExitState()
    {
        agent.agentWeaponManager.ToggleWeaponVisibility(false);
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying == false) { return; } // wtf pro ?

        Gizmos.color =  Color.red;
        var pos = agent.agentWeaponManager.transform.position;
        agent.agentWeaponManager.GetCurrentWeapon().DrawWeaponGizmo(pos, direction);
    }
}
