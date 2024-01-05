using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRow : RowBehaviour
{
    public ItemView ItemViewPrefab;

    //[SerializeField]
    public ItemObject _rowItemType;
    [SerializeField]
    private List<InventorySlot> _rowItemSlots;

    public void CustomConstructor(ItemObject rowItemType)
    {
        _rowItemType = rowItemType;

        AddRowItems();
        InitializeRowItems();
    }

    public override void AddRowItems()
    {
        _rowItemSlots.AddRange(ListRowItems());
    }

    public override void InitializeRowItems()
    {
        for (int i = 0; i < _rowItemSlots.Count; i++)
        {
            ItemView item = Instantiate(ItemViewPrefab, transform);
            item.InitializeItemView(_rowItemSlots[i]);
        }
    }

    public override void ReInitializeRow()
    {
        ResetRow();

        base.ReInitializeRow();
    }

    void ResetRow()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ItemView>())
                Destroy(transform.GetChild(i).gameObject);
        }
        _rowItemSlots.Clear();
    }

    private List<InventorySlot> ListRowItems()
    {
        List<InventorySlot> relativeItems = new List<InventorySlot>();

        for (int i = 0; i < TargetInventory.Container.Items.Count; i++)
        {
            int ItemObjectId = TargetInventory.Container.Items[i].Item.Id;
            InventoryObject inventoryObject = (InventoryObject)TargetInventory;
            var InventoryObjectType = inventoryObject.database.GetItem(ItemObjectId).GetType();

            if (_rowItemType.GetType() == InventoryObjectType)
            {
                relativeItems.Add(TargetInventory.Container.Items[i]);
            }
        }

        return relativeItems;
    }
}
