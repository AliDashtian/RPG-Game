using UnityEngine;

public class Weapon : EquipableItem
{
    [Header("Weapon Description")]
    public WeaponTypes WeaponType;
    public float Damage;

    private void Awake()
    {
        EquipableType = EquipableTypes.Weapon;
    }
}
