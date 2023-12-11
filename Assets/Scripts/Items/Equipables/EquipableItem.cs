using UnityEngine;

public class EquipableItem : ItemObject
{
    [Header("Equipable Description")]
    public EquipableTypes EquipableType;
    public float Weight;

    private void Awake()
    {
        ItemType = ItemTypes.Equipable;
        IsStackable = false;
    }
}
