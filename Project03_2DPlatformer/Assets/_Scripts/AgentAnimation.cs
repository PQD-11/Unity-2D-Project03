using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void PlayAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.attack:
                break;
            case AnimationType.climb:
                Play("Climbing");
                break;
            case AnimationType.die:
                break;
            case AnimationType.fall:
                Play("Fall");
                break;
            case AnimationType.hit:
                break;
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.jump:
                Play("Jump");
                break;
            case AnimationType.land:
                break;
            case AnimationType.run:
                Play("Run");
                break;
            default:
                break;
        }
    }

    public void StopAnimation()
    {
        animator.enabled = false;
    }

    public void StartAnimation()
    {
        animator.enabled = true;
    }

    public void Play(string name)
    {
        animator.Play(name, -1, 0f);
    }
}

public enum AnimationType
{
    die,
    hit,
    idle,
    attack,
    run,
    jump,
    fall,
    climb,
    land
}