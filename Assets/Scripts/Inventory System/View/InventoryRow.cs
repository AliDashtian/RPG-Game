using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryRow : MonoBehaviour
{
    public ItemObject RowItemType;

    public bool InitializeRowWithInspectorValue;
    public InventoryObject InventoryObject;
    public ItemView ItemViewPrefab;

    public List<InventorySlot> RowItemSlots;

    private void Start()
    {
        if (InitializeRowWithInspectorValue)
            InitializeRow(RowItemType);
    }

    private void OnEnable()
    {
        InventoryObject.OnInventoryChanged += ResetAndInitialize;
    }

    private void OnDisable()
    {
        InventoryObject.OnInventoryChanged -= ResetAndInitialize;
    }

    public void InitializeRow(ItemObject rowItemType)
    {
        RowItemType = rowItemType;

        RowItemSlots.AddRange(ListRelativeItems());
        CreateAndInitializeItems();
    }

    public void ResetAndInitialize()
    {
        ResetRow();

        RowItemSlots.AddRange(ListRelativeItems());
        CreateAndInitializeItems();
    }

    void ResetRow()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ItemView>())
                Destroy(transform.GetChild(i).gameObject);
        }
        RowItemSlots.Clear();
    }

    private List<InventorySlot> ListRelativeItems()
    {
        List<InventorySlot> relativeItems = new List<InventorySlot>();

        for (int i = 0; i < InventoryObject.Container.Items.Count; i++)
        {
            int ItemObjectId = InventoryObject.Container.Items[i].Item.Id;
            var InventoryObjectType = InventoryObject.database.GetItem(ItemObjectId).GetType();

            if (RowItemType.GetType() == InventoryObjectType)
            {
                relativeItems.Add(InventoryObject.Container.Items[i]);
            }
        }

        return relativeItems;
    }

    private void CreateAndInitializeItems()
    {
        for (int i = 0; i < RowItemSlots.Count; i++)
        {
            ItemView item = Instantiate(ItemViewPrefab, transform);
            item.InitializeItemView(RowItemSlots[i]);
        }
    }
}
