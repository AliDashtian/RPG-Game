using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();

    public bool HasItem(int index)
    {
        if (Items[index] != null)
        {
            if (Items[index].IsInitialized())
                return true;
        }

        return false;
    }
}
