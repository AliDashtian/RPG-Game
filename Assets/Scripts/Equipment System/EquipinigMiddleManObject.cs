using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EquipingMiddleMan")]
public class EquipinigMiddleManObject : ScriptableObject
{
    public InventoryObject PlayerInventory;

    [SerializeField]
    private int EquipmentPlaceID;
    [SerializeField]
    private EquipmentObject EquipmentObjectPlace;

    public void FillInfo(int id, EquipmentObject equipmentObject)
    {
        EquipmentPlaceID = id;
        EquipmentObjectPlace = equipmentObject;
    }

    public void Equip(InventorySlot item)
    {
        if (EquipmentObjectPlace.Container.HasItem(EquipmentPlaceID))
        {
            Debug.Log("Swaping");
            Swap(item);
            return;
        }

        Debug.Log("Equiping");

        EquipmentObjectPlace.Equip(EquipmentPlaceID, item);
    }

    public void Dequip(InventorySlot item)
    {
        if (!EquipmentObjectPlace.Container.HasItem(EquipmentPlaceID))
        {
            return;
        }

        Debug.Log("Dequiping");

        EquipmentObjectPlace.Dequip(EquipmentPlaceID);
        DeqiupFromInventory(item);
    }

    void Swap(InventorySlot item)
    {
        //EquipmentObjectPlace.Dequip(EquipmentPlaceID);
        Dequip(EquipmentObjectPlace.Container.Items[EquipmentPlaceID]);

        EquipmentObjectPlace.Equip(EquipmentPlaceID, item);
    }

    void DeqiupFromInventory(InventorySlot item)
    {
        PlayerInventory.Container.Items[item.InventoryId].ChangeBeingCarried(false);
    }
}
