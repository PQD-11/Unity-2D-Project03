using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

namespace SVS.PlayerAgent
{
    public class WeaponsManager : MonoBehaviour
    {
        public List<WeaponData> weaponList;
        Dictionary<string, WeaponData> weaponsDictionary = new Dictionary<string, WeaponData>();

        private void Awake()
        {
            AddToDictionary(weaponList);
        }

        private void AddToDictionary(List<WeaponData> weaponList)
        {
            foreach (WeaponData item in weaponList)
            {
                if (weaponsDictionary.ContainsKey(item.name)) continue;
                weaponsDictionary.Add(item.name, item);
            }
        }

        public WeaponData GetWeaponWithName(string name)
        {
            if (weaponsDictionary.ContainsKey(name)) 
            {
                return weaponsDictionary[name];
            }
            return null;
        }
    }
}
