using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using WeaponSystem;

public class Agent : MonoBehaviour
{
    public AgentDataSO agentDataSO;
    public Rigidbody2D rb2d;
    public PlayerInput playerInput;
    public AgentAnimation animationManager;
    public AgentRenderer agentRenderer;
    public GroundDetector groundDetector;
    public ClimbingDetector climbingDetector;
    public State currentState = null, previousState = null;
    public State IdleState;

    [HideInInspector]
    public AgentWeaponManager agentWeaponManager;

    public StateFactory stateFactory;
    private Damageable damageable;

    [Header("State Debugging: ")]
    public string stateName = "";

    [field: SerializeField] private UnityEvent OnRespawnRequired { get; set; }
    [field: SerializeField] public UnityEvent OnAgentDie { get; set; }

    private void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        climbingDetector = GetComponentInChildren<ClimbingDetector>();
        agentWeaponManager = GetComponentInChildren<AgentWeaponManager>();
        stateFactory = GetComponentInChildren<StateFactory>();
        damageable = GetComponent<Damageable>();

        stateFactory.InitializeStates(this);
    }
    private void Start()
    {
        playerInput.OnMovement += agentRenderer.FaceDirection;
        InitializeAgent();
    }

    private void InitializeAgent()
    {
        TransitionToState(IdleState);
        damageable.Initialize(agentDataSO.health);
    }

    private void Update()
    {
        currentState.StateUpdate();
    }

    private void FixedUpdate()
    {
        groundDetector.CheckIsGrounded();
        currentState.StateFixedUpdate();
    }

    public void TransitionToState(State desiredState)
    {
        if (desiredState == null) { return; }
        if (currentState != null)
        {
            currentState.Exit();
        }

        previousState = currentState;
        currentState = desiredState;
        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }

    public void AgentDied()
    {
        if (damageable.CurrentHealth > 0)
        {
        OnRespawnRequired?.Invoke();
        }
        else
        {
            currentState.Die();
        }
    }

    public void GetHit()
    {
        currentState.GetHit();
    }
}