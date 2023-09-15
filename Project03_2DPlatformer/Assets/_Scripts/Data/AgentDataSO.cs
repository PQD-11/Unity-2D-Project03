using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/Data")]
public class AgentDataSO : ScriptableObject
{
    [Header("HealthData")]
    [Space]
    public int health = 2;

    [Header("MovemetData")]
    [Space]
    public float maxSpeed = 6;
    public float acceleration = 50;
    public float deacceleration = 50;

    [Header("JumpData")]
    [Space]
    public float jumpForce = 12;
    public float lowJumpMultiplier = 2;
    public float gravityModifier = 0.5f;

    [Header("ClimbData")]
    [Space]
    public float climbHorizontalSpeed = 2;
    public float climbVecticalSpeed = 5;
}
