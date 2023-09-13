using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class AgentWeaponManager : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private WeaponStorage weaponStorage;
        public UnityEvent<Sprite> OnWeaponSwap;
        public UnityEvent OnMultipleWeapons;
        public UnityEvent OnWeaponPickup;

        private void Awake()
        {
            weaponStorage = new WeaponStorage();
            spriteRenderer = GetComponent<SpriteRenderer>();
            ToggleWeaponVisibility(false);
        }

        private void ToggleWeaponVisibility(bool v)
        {
            if (v)
            {
                SwapWeaponSprite(GetCurrentWeapon().weaponSprite);
            }
            spriteRenderer.enabled = v;
        }

        public WeaponData GetCurrentWeapon()
        {
            return weaponStorage.GetCurrentWeapon();
        }

        private void SwapWeaponSprite(Sprite weaponSprite)
        {
            spriteRenderer.sprite = weaponSprite;
            OnWeaponSwap?.Invoke(weaponSprite);
        }

        public void SwapWeapon()
        {
            if (weaponStorage.WeaponCount <= 0) { return; }

            SwapWeaponSprite(weaponStorage.SwapWeapon().weaponSprite);
        }

        public void AddWeaponData(WeaponData weaponData)
        {
            if (!weaponStorage.AddWeaponData(weaponData)) { return; }
            
            if (weaponStorage.WeaponCount == 2)
            {
                OnMultipleWeapons?.Invoke();
            }
            SwapWeaponSprite(weaponData.weaponSprite);
        }

        public void PickUpWeapon(WeaponData weaponData)
        {
            AddWeaponData(weaponData);
            OnWeaponPickup?.Invoke();
        }

        public bool CanUseWeapon(bool isGrounded)
        {
            if (weaponStorage.WeaponCount <= 0) { return false; }

            return weaponStorage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetPlayerWeaponNames()
        {
            return weaponStorage.GetPlayerWeaponNames();
        }
    }
}

