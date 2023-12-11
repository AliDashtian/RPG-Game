using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemViewInfo")]
public class ItemViewObject : ScriptableObject
{
    public InventoryObject PlayerInventory;

    public ItemViewInfo GetItemInfo(InventorySlot inventorySlot)
    {
        //InventorySlot inventorySlot = PlayerInventory.Container.Items[inventoryId];
        ItemObject itemObject = PlayerInventory.database.GetItem(inventorySlot.Item.Id);

        string name = inventorySlot.Item.Name;
        int stackSize = inventorySlot.StackSize;
        bool beingCarried = inventorySlot.BeingCarried;

        string description = itemObject.Description;
        Sprite sprite = itemObject.Sprite;

        ItemViewInfo itemViewInfo = new ItemViewInfo(name, description, sprite, stackSize, beingCarried);

        return itemViewInfo;
    }
}
