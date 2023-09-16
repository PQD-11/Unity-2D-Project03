using System.Collections;
using System.Collections.Generic;

using SVS.AI;
using UnityEngine;

namespace SVS.AI
{
    public class AIBehaviorPatrol : AIBehavior
    {
        public AIEndPlatformDetector changDirectionDetector;
        private Vector2 movementVector = Vector2.zero;

        private void Awake()
        {
            if (changDirectionDetector == null)
            {
                changDirectionDetector = GetComponentInChildren<AIEndPlatformDetector>();
            }
        }

        private void Start()
        {
            changDirectionDetector.OnPathBlocked += HandlePathBlocked;
            movementVector = new Vector2(1, 0);
        }

        private void HandlePathBlocked()
        {
            movementVector *= new Vector2(-1, 0);
        }
        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = movementVector;
            enemyAI.CallOnMovement(movementVector);
        }

    }

}

