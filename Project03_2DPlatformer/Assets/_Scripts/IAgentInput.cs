using System;
using UnityEngine;
using UnityEngine.Timeline;

public interface IAgentInput
{
    Vector2 MovementVector { get; }

    event Action OnAttack;
    event Action OnJumpPressed;
    event Action OnJumpReleased;
    event Action OnWeaponChange;
    event Action<Vector2> OnMovement;
}
