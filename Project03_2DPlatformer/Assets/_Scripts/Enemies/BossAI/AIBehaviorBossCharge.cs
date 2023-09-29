using System;
using System.Collections;
using System.Collections.Generic;
using SVS.AI;
using UnityEngine;

namespace SVS.AI
{
    public class AIBehaviorBossCharge : AIBehavior
    {
        [SerializeField] private AIDataBoard aiBoard;
        [SerializeField] private AIPlayerEnterAreaDetector playerDetector;
        [SerializeField] private Agent agent;

        private Vector3 tempPosition;
        private Vector2 direction;
        private bool isInitialized;
        public override void PerformAction(AIEnemy enemyAI)
        {
            if (aiBoard.CheckBoard(AIDataTypes.Arrived))
            {
                isInitialized = false;
            }

            SetChargeDestination();

            ChargeAtThePlayer(enemyAI);

            if (aiBoard.CheckBoard(AIDataTypes.PathBlocked))
            {
                enemyAI.CallOnMovement(Vector2.zero);
                enemyAI.MovementVector = Vector2.zero;

                aiBoard.SetBoard(AIDataTypes.Waiting, true);
                aiBoard.SetBoard(AIDataTypes.Arrived, true);
            }
        }

        private void ChargeAtThePlayer(AIEnemy enemyAI)
        {
            enemyAI.CallOnMovement(direction.normalized);
            enemyAI.MovementVector = direction.normalized;
        }

        private void SetChargeDestination()
        {
            if (isInitialized)
            {
                return;
            }

            tempPosition = new Vector2(playerDetector.Player.position.x, agent.transform.position.y);
            direction = tempPosition - agent.transform.position;
            aiBoard.SetBoard(AIDataTypes.Arrived, false);
            isInitialized = true;
        }
    }
}

