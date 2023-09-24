using System.Collections;
using System.Collections.Generic;
using SVS.Levels;
using UnityEngine;
using WeaponSystem;

namespace SVS.PlayerAgent
{
    public class Player : MonoBehaviour, ISaveData
    {
        private WeaponsManager weaponsManager;
        [SerializeField] private AgentWeaponManager playerWeapons;

        private void Awake()
        {
            weaponsManager = FindObjectOfType<WeaponsManager>();
        }
        public void LoadData()
        {
            List<string> weaponsNames = SaveSystem.LoadWeapons();
            if (weaponsNames != null)
            {
                foreach (string name in weaponsNames)
                {
                    Debug.Log("Loading weapon :" + name);
                    WeaponData weapon = weaponsManager.GetWeaponWithName(name);
                    playerWeapons.AddWeaponData(weapon);
                }
            }
            else
            {
                Debug.Log("No weapon data to load");
            }
        }

        public void SaveData()
        {
            List<string> weaponsNames = playerWeapons.GetPlayerWeaponNames();
            Debug.Log(weaponsNames);

            if (weaponsNames != null && weaponsNames.Count > 0)
            {
                SaveSystem.SeveWeapons(weaponsNames);
            }

        }
    }
}

