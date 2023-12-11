using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Runtime.Serialization;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string SavePath;
    public ItemDatabase database;
    public Inventory Container;

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

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, SavePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, SavePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, SavePath), FileMode.Open, FileAccess.Read);
            Container = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
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
