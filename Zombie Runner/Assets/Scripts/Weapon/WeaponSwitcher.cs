using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] public int currentWeapon = 0;

    private StarterAssetsInputs _input;

    void Start()
    {
        _input = GetComponentInParent<StarterAssetsInputs>();
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (_input.key1)
        {
            currentWeapon = 0;
            _input.key1 = false;
        }
        if (_input.key2)
        {
            currentWeapon = 1;
            _input.key2 = false;
        }
        if (_input.key3)
        {
            currentWeapon = 2;
            _input.key3 = false;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
