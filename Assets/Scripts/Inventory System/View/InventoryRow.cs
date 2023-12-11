using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRow : MonoBehaviour, IRowView
{
    public ItemObject RowItemType;

    public bool InitializeRowWithInspectorValue;
    public InventoryObject InventoryObject;
    public ItemView ItemViewPrefab;

    public List<InventorySlot> RowItemsObjects;

    private void Start()
    {
        if (InitializeRowWithInspectorValue)
            InitializeRow(RowItemType);
    }

    public void InitializeRow(ItemObject rowItemType)
    {
        RowItemType = rowItemType;

        SelectRelativeItemsForRowView();
        CreateOrUpdateRowItems();
    }

    private void SelectRelativeItemsForRowView()
    {
        for (int i = 0; i < InventoryObject.Container.Items.Count; i++)
        {
            int ItemObjectId = InventoryObject.Container.Items[i].Item.Id;
            var InventoryObjectType = InventoryObject.database.GetItem(ItemObjectId).GetType();

            if (RowItemType.GetType() == InventoryObjectType)
            {
                RowItemsObjects.Add(InventoryObject.Container.Items[i]);
            }
        }
    }

    public void CreateOrUpdateRowItems()
    {
        for (int i = 0; i < RowItemsObjects.Count; i++)
        {
            ItemView item = Instantiate(ItemViewPrefab, transform);
            item.InitializeItemView(RowItemsObjects[i]);
        }
    }
}
