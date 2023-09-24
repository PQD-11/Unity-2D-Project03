using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

namespace SVS.Levels
{
    public class ExitLevelTransition : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";
        [SerializeField] private string inputAxisName = "Vertical";
        [SerializeField] private int inputAxisValue = 1;

        private bool playerInRange;

        public UnityEvent OnPlayerEnter, OnPlayerExit, OnTransition;

        private void Update()
        {
            if (playerInRange)
            {
                if ((int)Input.GetAxisRaw(inputAxisName) >= inputAxisValue)
                {
                    OnTransition?.Invoke();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                playerInRange = true;
                OnPlayerEnter?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                OnPlayerExit?.Invoke();
            }
        }

    }
}

