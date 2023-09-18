using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.Pickable
{
    public class HealthPickable : Pickable
    {
        [SerializeField] private int healthBoost = 1;

        public override void PickUp(Agent agent)
        {
            Damageable damageable = agent.GetComponent<Damageable>();
            if (damageable == null) { return; }
            damageable.RestoreHealth(healthBoost);
        }
    }
}
