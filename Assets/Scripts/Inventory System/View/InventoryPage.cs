using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryPage : MonoBehaviour
{
    public List<ItemObject> PageTypeObject = new List<ItemObject>();
    public InventoryObject InventoryObject;
    public InventoryRow RowPrefab;
    public List<ItemObject> RowsTypes;

    private void OnEnable()
    {
        FindAllPageRowTypes();
        CreateAndInitializeRows();
    }

    private void OnDisable()
    {
        ResetPage();
    }

    public void ResetPage()
    {
        RowsTypes.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            InventoryRow inventoryRow;
            if (transform.GetChild(i).TryGetComponent(out inventoryRow))
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

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
        for (int i = 0; i < InventoryObject.Container.Items.Count; i++)
        {
            bool isItemTypeAlreadyAdded = false;
            int ItemObjectId = InventoryObject.Container.Items[i].Item.Id;

            var InventoryObjectBaseType = InventoryObject.database.GetItem(ItemObjectId).GetType().BaseType;
            var InventoryObjectType = InventoryObject.database.GetItem(ItemObjectId).GetType();

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
                    RowsTypes.Add(InventoryObject.database.GetItem(ItemObjectId));
            }
        }
    }

    void CreateAndInitializeRows()
    {
        for (int i = 0; i < RowsTypes.Count; i++)
        {
            InventoryRow rowPrefab = Instantiate(RowPrefab, transform);
            rowPrefab.InitializeRow(RowsTypes[i]);
        }
    }
}
