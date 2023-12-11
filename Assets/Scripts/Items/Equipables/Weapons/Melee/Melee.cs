using System;

public class Melee : Weapon
{
    public MeleeTypes MeleeType;

    private void Awake()
    {
        WeaponType = WeaponTypes.Melee;
    }
}
