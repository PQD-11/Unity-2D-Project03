using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateFactory : MonoBehaviour
{
    [SerializeField]
    private State Idle, Move, Fall, Jump, Climbing, Attack, GetHit, Die;

    public State GetState(StateType stateType)
        => stateType switch
        {
            StateType.Idle => Idle,
            StateType.Move => Move,
            StateType.Fall => Fall,
            StateType.Jump => Jump,
            StateType.Climbing => Climbing,
            StateType.Attack => Attack,
            StateType.GetHit => GetHit,
            StateType.Die => Die,
            _ => throw new System.Exception("State Not Definded: " + stateType.ToString())
        };

    public void InitializeStates(Agent agent)
    {
        State[] states = GetComponents<State>();
        foreach (var state in states)
        {
            state.InitializeState(agent);
        }
    }
}

public enum StateType
{
    Idle,
    Move,
    Fall,
    Jump,
    Climbing,
    Attack,
    GetHit,
    Die
}
