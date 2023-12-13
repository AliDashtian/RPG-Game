using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    public int ID;
    public EquipmentObject SlotPlace;
    public ItemView ItemViewPrefab;

    public InventorySlot Item;

    public void InitializeSlot(int id, EquipmentObject equipmentObject)
    {
        ID = id;
        SlotPlace = equipmentObject;
        Item = SlotPlace.Container.Items[ID];

        if (SlotPlace.Container.HasItem(ID))
        {
            ItemViewPrefab.ShowBeingCarried = false;

            ItemViewPrefab.InitializeItemView(Item);
        }
        else
        {
            ItemViewPrefab.ClearItemView();
        }

    }
}
