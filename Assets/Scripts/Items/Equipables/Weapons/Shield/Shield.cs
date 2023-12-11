using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/Shield")]
public class Shield : Weapon
{

    private void Awake()
    {
        WeaponType = WeaponTypes.Shield;
    }
}
