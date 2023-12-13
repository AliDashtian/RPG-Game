using System;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "ScriptableObjects/EquipmentInventory")]
public class EquipmentObject : InventoryBaseObject
{

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
}
