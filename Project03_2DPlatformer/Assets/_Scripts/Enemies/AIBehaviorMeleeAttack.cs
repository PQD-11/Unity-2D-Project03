using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.AI
{
    public class AIBehaviorMeleeAttack : AIBehavior
    {
        public AIDetectorForMeleeAttack detectorForMeleeAttack;

        [SerializeField] private bool isWaiting;

        [SerializeField] private float delay = 1;

        private void Awake()
        {
            if (detectorForMeleeAttack == null)
            {
                // detectorForMeleeAttack = transform.parent.GetComponentInParent<AIDetectorForMeleeAttack>();
            }
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isWaiting) { return; }

            if (!detectorForMeleeAttack.PlayerDetected) { return; }

            enemyAI.CallOnAttack();
            isWaiting = true;
            StartCoroutine(AttackDelayCoroutine());
        }

        IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSecondsRealtime(delay);
            isWaiting = false;
        }

    }
}


