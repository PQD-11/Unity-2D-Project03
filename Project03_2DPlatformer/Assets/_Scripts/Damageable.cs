using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class Damageable : MonoBehaviour, IHittable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            OnHealthChanged?.Invoke(currentHealth);
        }
    }

    public UnityEvent OneGetHit;
    public UnityEvent OnDie;
    public UnityEvent OnRestoreHealth;

    public UnityEvent<int> OnHealthChanged;
    public UnityEvent<int> OnInitialHealth;

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        GetHit(weaponDamage);
    }

    public void GetHit(int weaponDamage)
    {
        CurrentHealth -= weaponDamage;

        if (CurrentHealth <= 0)
        {
            OnDie?.Invoke();
        }
        else
        {
            OneGetHit?.Invoke();
        }
    }

    public void RestoreHealth(int val)
    {
        CurrentHealth = Mathf.Clamp(currentHealth + val, 0, maxHealth);
        OnRestoreHealth?.Invoke();
    }

    public void Initialize(int health)
    {
        maxHealth = health;
        OnInitialHealth?.Invoke(maxHealth);
        CurrentHealth = maxHealth;
    }
}
