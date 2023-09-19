using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image weaponSprite;
    [SerializeField] private GameObject weaponSwapTip;

    public UnityEvent SwapWeaponEvent, ToggleWeaponTipUI;

    private void Start()
    {
        weaponSprite.enabled = false;
        weaponSprite.sprite = null;
        weaponSwapTip.SetActive(false);
    }

    public void SetWeaponImage(Sprite sprite)
    {
        if (weaponSprite.sprite == sprite) { return; }

        weaponSprite.enabled = true;
        weaponSprite.sprite = sprite;
        SwapWeaponEvent?.Invoke();
    }

    public void ToggleWeaponTip(bool val)
    {
        weaponSwapTip.SetActive(val);
        if (val)
        {
            ToggleWeaponTipUI?.Invoke();
        }
    }
}
