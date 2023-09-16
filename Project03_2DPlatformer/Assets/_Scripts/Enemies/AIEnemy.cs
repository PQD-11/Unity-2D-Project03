using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SVS.AI
{
    public abstract class AIEnemy : MonoBehaviour, IAgentInput
    {
        public Vector2 MovementVector { get; set; }

        public event Action OnAttack;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action OnWeaponChange;
        public event Action<Vector2> OnMovement;

        public void CallOnAttack()
        {
            OnAttack?.Invoke();
        }
        
        public void CallOnJumpPressed()
        {
            OnJumpPressed?.Invoke();
        }

        public void CallOnJumpReleased()
        {
            OnJumpReleased?.Invoke();
        }

        public void CallOnWeaponChange()
        {
            OnWeaponChange?.Invoke();
        }

        public void CallOnMovement(Vector2 vector2)
        {
            OnMovement?.Invoke(vector2);
        }
    }
}

