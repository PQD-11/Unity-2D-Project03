using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class DieState : State
{
    public float timeToWaitAfterDieAction = 1;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.die);
        agent.animationManager.OnAnimationEnd.AddListener(HandleBeforeRespawn);
        agent.rb2d.velocity = new Vector2(0, agent.rb2d.velocity.y);
    }

    protected override void HandleAttack()
    {
        //prevent
    }

    protected override void HandleJumpPressed()
    {
        //prevent
    }
    public override void StateUpdate()
    {
        agent.rb2d.velocity = new Vector2(0, agent.rb2d.velocity.y);
        //prevent
    }
    public override void GetHit()
    {
        //prevent
    }
    public override void Die()
    {
        //prevent
    }

    private void HandleBeforeRespawn()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(HandleBeforeRespawn);
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSecondsRealtime(timeToWaitAfterDieAction);
        agent.OnAgentDie?.Invoke();
    }

    protected override void ExitState()
    {
        StopAllCoroutines();
        agent.animationManager.ResetEvents();
    }
}
