using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class WeaponData : ScriptableObject, IEquatable<WeaponData>
    {
        public Sprite weaponSprite;
        public string weaponName;
        public int weaponDamage = 1;
        public AudioClip weaponSwingSound;

        public abstract bool CanBeUsed(bool isGrounded);

        public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
        }
        public bool Equals(WeaponData other)
        {
            return weaponName == other.weaponName;
        }
    }
}

