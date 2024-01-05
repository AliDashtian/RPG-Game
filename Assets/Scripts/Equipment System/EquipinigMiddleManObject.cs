using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EquipingMiddleMan")]
public class EquipinigMiddleManObject : ScriptableObject
{
    public InventoryObject PlayerInventory;
    public InventorySlot CurrentItem;

    [SerializeField]
    private int EquipmentPlaceID;
    [SerializeField]
    private EquipmentObject EquipmentObject;

    public void FillInfo(int id, InventoryBaseObject equipmentObject, InventorySlot currentItem)
    {
        EquipmentPlaceID = id;
        EquipmentObject = (EquipmentObject) equipmentObject;
        CurrentItem = currentItem;
    }

    public void Equip(InventorySlot item)
    {
        if (EquipmentObject.Container.HasItem(EquipmentPlaceID))
        {
            Debug.Log("Swap from equip function");

            Swap(item);
            return;
        }

        Debug.Log("Equiping");

        EquipmentObject.Equip(EquipmentPlaceID, item);
    }

    public void Dequip(InventorySlot item)
    {
        if (!EquipmentObject.Container.HasItem(EquipmentPlaceID))
        {
            Debug.Log("No Item to Dequip");
            return;
        }

        Debug.Log("Dequiping");

        EquipmentObject.Dequip(EquipmentPlaceID);
        DeqiupFromInventory(item);
    }

    public void Swap(InventorySlot item)
    {
        Debug.Log("Swapingggg");

        //EquipmentObjectPlace.Dequip(EquipmentPlaceID);
        Dequip(CurrentItem);

        EquipmentObject.Equip(EquipmentPlaceID, item);
    }

    void DeqiupFromInventory(InventorySlot item)
    {
        PlayerInventory.Container.Items[item.InventoryId].ChangeBeingCarried(false);
    }
}
