using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EquipmentInventory")]
public class EquipmentObject : InventoryObject
{
    public EquipablePlaces Place;

    public event Action EquipmentChanged;

    public void Equip(int index, InventorySlot item)
    {
        Container.Items[index] = item;
        Container.Items[index].ChangeBeingCarried(true);
        Container.Items[index].InventoryId = item.InventoryId;

        InvokeEquipmentChanged();
    }

    public void Dequip(int index)
    {
        //Debug.Log("Dequiping : " + Container.Items[index].ItemObject.name);

        Container.Items[index].ChangeBeingCarried(false);
        Container.Items[index] = null;

        InvokeEquipmentChanged();
    }

    public void InvokeEquipmentChanged()
    {
        EquipmentChanged.Invoke();
    }
}
