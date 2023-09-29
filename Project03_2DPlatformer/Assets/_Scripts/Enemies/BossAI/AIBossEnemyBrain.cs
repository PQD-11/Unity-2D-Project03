using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.AI
{
    public class AIBossEnemyBrain : AIEnemy
    {
        [SerializeField] private AIDataBoard aiBoard;
        [SerializeField] private AIPlayerEnterAreaDetector playerDetector;
        [SerializeField] private AIDetectorForMeleeAttack meleeRangeDetector;
        [SerializeField] private AIEndPlatformDetector endPlatformDetector;

        [SerializeField] private AIBehavior IdleBehavior, ChargeBehavior, MeleeAttackBehavior, WaitBehavior;

        private void Update()
        {
            aiBoard.SetBoard(AIDataTypes.PlayerDetected, playerDetector.PlayerInArea);
            aiBoard.SetBoard(AIDataTypes.InMeleeRange, meleeRangeDetector.PlayerDetected);
            aiBoard.SetBoard(AIDataTypes.PathBlocked, endPlatformDetector.PathBlocked);

            if (aiBoard.CheckBoard(AIDataTypes.PlayerDetected))
            {
                if (aiBoard.CheckBoard(AIDataTypes.Waiting))
                {
                    WaitBehavior.PerformAction(this);
                }
                else
                {
                    if (aiBoard.CheckBoard(AIDataTypes.InMeleeRange))
                    {
                        MeleeAttackBehavior.PerformAction(this);
                    }
                    else
                    {
                        ChargeBehavior.PerformAction(this);
                    }
                }
            }
            else
            {
                IdleBehavior.PerformAction(this);
            }

        }
    }
}


