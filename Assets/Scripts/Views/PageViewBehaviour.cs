using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageViewBehaviour : MonoBehaviour
{
    public InventoryObject Inventory;
    public List<ItemObject> PageTypeObject = new List<ItemObject>();

    [SerializeField]
    private List<ItemObject> RowsTypes;

    void FindAllPageRowTypes()
    {
        for (int i = 0; i < PageTypeObject.Count; i++)
        {
            var objectType = PageTypeObject[i].GetType().BaseType;

            FindRelativeTypeAndAddToList(objectType);
        }
    }

    void FindRelativeTypeAndAddToList(Type objectType)
    {
        for (int i = 0; i < Inventory.Container.Items.Count; i++)
        {
            bool isItemTypeAlreadyAdded = false;
            int ItemObjectId = Inventory.Container.Items[i].Item.Id;

            var InventoryObjectBaseType = Inventory.database.GetItem(ItemObjectId).GetType().BaseType;
            var InventoryObjectType = Inventory.database.GetItem(ItemObjectId).GetType();

            if (objectType == InventoryObjectBaseType)
            {
                for (int j = 0; j < RowsTypes.Count; j++)
                {
                    if (InventoryObjectType == RowsTypes[j].GetType())
                    {
                        isItemTypeAlreadyAdded = true;
                    }
                }

                if (!isItemTypeAlreadyAdded)
                    RowsTypes.Add(Inventory.database.GetItem(ItemObjectId));
            }
        }
    }
}
