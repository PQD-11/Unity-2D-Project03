using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private List<LifeElementUI> lifeList;

    [SerializeField] private Sprite fullHealth, emptyHealth;
    [SerializeField] private LifeElementUI lifePrefabs;

    public void Initialize(int maxHealth)
    {
        lifeList = new List<LifeElementUI>();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHealth; i++)
        {
            var life = Instantiate(lifePrefabs);
            life.transform.SetParent(transform, false);
            lifeList.Add(life);
        }
    }

    public void SetHealth(int currentHealth)
    {
        for (int i = 0; i < lifeList.Count; i++)
        {
            if (i < currentHealth)
            {
                lifeList[i].SetSprite(fullHealth);
            }
            else
            {
                lifeList[i].SetSprite(emptyHealth);
            }
        }
    }
}
