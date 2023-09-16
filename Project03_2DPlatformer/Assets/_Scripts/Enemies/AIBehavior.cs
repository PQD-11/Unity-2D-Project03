using System;
using System.Collections;
using System.Collections.Generic;
using SVS.AI;
using UnityEditor.Scripting;
using UnityEngine;

namespace SVS.AI
{
    public abstract class AIBehavior : MonoBehaviour
    {
        public abstract void PerformAction(AIEnemy enemyAI);
    }
}
