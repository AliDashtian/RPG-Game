using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObjects/EquipmentInventory")]
public class EquipmentObject : InventoryBaseObject
{
    public int EquipmentSize = 4;

    public void Equip(int index, InventorySlot item)
    {
        Container.Items[index] = item;
        Container.Items[index].ChangeBeingCarried(true);
        Container.Items[index].InventoryId = item.InventoryId;

        InvokeOnInventoryChanged();
    }

    public void Dequip(int index)
    {
        //Debug.Log("Dequiping : " + Container.Items[index].ItemObject.name);

        Container.Items[index].ChangeBeingCarried(false);
        Container.Items[index] = null;

        InvokeOnInventoryChanged();
    }

    void DequipIfNotCarried()
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (!Container.Items[i].BeingCarried)
                Dequip(i);
        }
    }

    [ContextMenu("ReInitialize Equipment")]
    public override void Clear()
    {
        base.Clear();
        Debug.Log("Clear equipments");

        Container.Items = new List<InventorySlot>(4);

        for (int i = 0;i < EquipmentSize;i++)
        {
            Container.Items.Add(null);
        }
    }
}
