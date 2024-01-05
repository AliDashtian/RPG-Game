using UnityEngine;

public class EquipmentView : MonoBehaviour
{ 
    public int ID;
    public InventoryBaseObject SlotPlace;
    public ItemView ItemViewPrefab;
    public InventorySlot Item;

    public void InitializeSlot(int id, InventoryBaseObject equipmentObject)
    {
        ID = id;
        SlotPlace = equipmentObject;
        Item = SlotPlace.Container.Items[ID];

        if (SlotPlace.Container.HasItem(ID))
        {
            ItemViewPrefab.ShowBeingCarried = false;

            ItemViewPrefab.InitializeItemView(Item);
        }
        else
        {
            ItemViewPrefab.ClearItemView();
        }
    }
}
