using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class FragileBlock : MonoBehaviour, IHittable
{
    public UnityEvent OnHit;

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        OnHit?.Invoke();
    }

/// <summary>
/// DestroySelf: Event called at the of the animation 
/// </summary>
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
