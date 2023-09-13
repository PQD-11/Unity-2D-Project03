using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "New Melee Weapon Data", menuName = "Weapons/MeleeWeaponData")]
    public class MeleeWeaponData : WeaponData
    {
        public float attackRange = 2;

        public override bool CanBeUsed(bool isGrounded)
        {
            return isGrounded == true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            RaycastHit2D hit = Physics2D.Raycast(agent.agentWeaponManager.transform.position, direction, attackRange, hittableMask);
        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
            Gizmos.DrawLine(origin, origin + direction * attackRange);
        }
    }
}

