using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.AI
{
    public class AIBehaviorBossWait : AIBehavior
    {
        [SerializeField] private AIDataBoard aiBoard;
        [SerializeField] private float waitTime = 1;
        
        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = Vector2.zero;
            StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine()
        {
            yield return new WaitForSecondsRealtime(waitTime);
            aiBoard.SetBoard(AIDataTypes.Waiting, false);
        }
    }
}

