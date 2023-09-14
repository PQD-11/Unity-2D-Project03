using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class GiveAgentAWeapon : MonoBehaviour
    {
        public List<WeaponData> weaponDatas = new List<WeaponData>();

        private void Start()
        {
            Agent agent = GetComponentInChildren<Agent>();

            if (agent == null) { return; }

            foreach (var item in weaponDatas)
            {
                agent.agentWeaponManager.AddWeaponData(item);
            }
        }

    }
}
