using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Runtime.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class InventoryObject : InventoryBaseObject
{
    public ItemDatabase database;

    public void AddItem(Item item, int amount)
    {
        int inventoryItemIndex = Container.Items.Count;

        if (!item.IsStackable)
        {
            Container.Items.Add(new InventorySlot(inventoryItemIndex, item));
            return;
        }

        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].Item.Id == item.Id)
            {
                Container.Items[i].AddAmount(amount);
                return;
            }
        }

        Container.Items.Add(new InventorySlot(inventoryItemIndex, item, amount));
    }

    private void OnValidate()
    {
        SetItemNameById();
    }

    void SetItemNameById()
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            Container.Items[i].Item.Name = database.Items[Container.Items[i].Item.Id].name;
            Container.Items[i].Item.Level = database.Items[Container.Items[i].Item.Id].Level;
            Container.Items[i].Item.IsStackable = database.Items[Container.Items[i].Item.Id].IsStackable;
        }
    }
}
