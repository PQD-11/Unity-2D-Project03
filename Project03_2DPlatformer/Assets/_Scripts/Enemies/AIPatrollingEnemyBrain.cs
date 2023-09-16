using System.Collections;
using System.Collections.Generic;
using SVS.AI;
using UnityEngine;

namespace SVS.AI
{
    public class AIPatrollingEnemyBrain : AIEnemy
    {
        public GroundDetector agentGroundDetector;

        public AIBehavior attackBehavior, patrolBehavior;

        private void Awake()
        {
            if (agentGroundDetector == null)
            {
                agentGroundDetector = GetComponentInChildren<GroundDetector>();
            }
        }

        private void Update()
        {
            if (agentGroundDetector.isGrounded)
            {
                attackBehavior.PerformAction(this);
                patrolBehavior.PerformAction(this);
            }
        }
    }
}

