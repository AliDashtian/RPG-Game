using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : ItemObject
{
    [Header("Consumable Description")]
    public ConsumableTypes ConsumableType;

    private void Awake()
    {
        ItemType = ItemTypes.Consumable;
        IsStackable = true;
    }
}
