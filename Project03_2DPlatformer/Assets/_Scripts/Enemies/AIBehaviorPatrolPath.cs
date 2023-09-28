using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

namespace SVS.AI
{
    public class AIBehaviorPatrolPath : AIBehavior
    {
        [SerializeField] PatrolFlyingPath patrolFlyingPath;

        [Range(0.1f, 1)]
        [SerializeField] private float arriveDistance = 1;
        [SerializeField] private float waitTime = 0.5f;
        [SerializeField] private bool isWaiting;
        [SerializeField] private Vector2 currentPointTarget = Vector2.zero;
        private bool isInitialized;

        [SerializeField] private Transform agent;
        private int currentIndex = -1; //Test public  

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isWaiting) { return; }

            if (patrolFlyingPath.Lenght < 2) { return; }

            if (!isInitialized)
            {
                var currentPathPoint = patrolFlyingPath.GetClosestPathPoint(agent.position);
                this.currentIndex = currentPathPoint.Index;
                this.currentPointTarget = currentPathPoint.Position;
                isInitialized = true;
            }

            if (Vector2.Distance(agent.position, currentPointTarget) < arriveDistance)
            {
                isWaiting = true;
                enemyAI.MovementVector = Vector2.zero;
                StartCoroutine(WaitCoroutine());    
                return;
            }

            Vector2 directionToGo = currentPointTarget - (Vector2)agent.position;

            enemyAI.CallOnMovement(directionToGo.normalized);
            enemyAI.MovementVector = directionToGo.normalized;

        }

        private IEnumerator WaitCoroutine()
        {
            yield return new WaitForSecondsRealtime(waitTime);
            var nextPathPoint = patrolFlyingPath.GetNextPathPoint(currentIndex);
            currentPointTarget = nextPathPoint.Position;
            currentIndex = nextPathPoint.Index;
            isWaiting = false;
        }
    }
}
