using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/RangWeaponData")]
    public class RangeWeaponData : WeaponData
    {
        public GameObject rangeWeaponPrefab;
        public float weaponThrowSpeed = 1;
        public float attackRange = 2;   

        public override bool CanBeUsed(bool isGrounded)
        {
            return true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            agent.agentWeaponManager.ToggleWeaponVisibility(false);
            GameObject throwable = Instantiate(rangeWeaponPrefab, agent.agentWeaponManager.transform.position, Quaternion.identity);
            throwable.GetComponent<ThrowableWeapon>().Initialize(this, direction, hittableMask);
        }
    }
}

