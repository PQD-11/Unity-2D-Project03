using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.AI
{
    public class AIBehaviorShoot : AIBehavior
    {
        public AIPlayerDetector playerDetector;
        [SerializeField] private bool isWaiting;
        [SerializeField] private float delay = 1;

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isWaiting) { return; }
            if (playerDetector.PlayerDetected)
            {
                isWaiting = true;
                enemyAI.CallOnMovement(playerDetector.DirectionToTarget);
                enemyAI.CallOnAttack();
                StartCoroutine(AttackDelayCoroutine());
            }
        }

        IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSecondsRealtime(delay);
            isWaiting = false;
        }
    }
}
