
[System.Serializable]
public class InventorySlot
{
    public int InventoryId = -1;
    public int StackSize;
    public bool BeingCarried;
    public Item Item;

    // for non stackables like weapons
    public InventorySlot(int inventoryId, Item item)
    {
        InventoryId = inventoryId;
        Item = item;
        StackSize = 1;
    }

    //for stackables like food
    public InventorySlot(int inventoryId, Item item, int amount)
    {
        InventoryId = inventoryId;
        Item = item;
        StackSize = amount;
    }

    public void AddAmount(int amount)
    {
        StackSize += amount;
    }

    public void ChangeBeingCarried(bool beingCarried)
    {
        BeingCarried = beingCarried;
    }

    public bool IsInitialized() => StackSize > 0;
}
