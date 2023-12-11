using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    public BowTypes BowType;

    private void Awake()
    {
        WeaponType = WeaponTypes.Bow;
    }
}
