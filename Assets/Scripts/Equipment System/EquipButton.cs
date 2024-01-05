using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public EquipinigMiddleManObject EquipinigMiddleMan;

    private InventorySlot MyItem;
    private ItemView MyItemView;

    private void OnEnable()
    {     
        GetComponent<Button>().onClick.AddListener(EquipOrDequip);
        MyItemView = GetComponent<ItemView>();
    }

    void EquipOrDequip()
    {
        MyItem = GetComponent<ItemView>().InventorySlot;

        if (EquipinigMiddleMan.CurrentItem.IsInitialized())
        {
            if (MyItem.Item.Id == EquipinigMiddleMan.CurrentItem.Item.Id)
                DequipButton();
            else if (!MyItem.BeingCarried)
                Swap();
        }
        else
        {
            EquipButtonFunction();
        }
    }

    void EquipButtonFunction()
    {
        EquipinigMiddleMan.Equip(MyItem);
        UpdateItemView(MyItemView);
    }

    void DequipButton()
    {
        EquipinigMiddleMan.Dequip(MyItem);
        UpdateItemView(MyItemView);
    }

    void Swap()
    {
        EquipinigMiddleMan.Swap(MyItem);
        UpdateItemView(MyItemView);
        EquipinigMiddleMan.PlayerInventory.InvokeOnInventoryChanged();
    }

    private void UpdateItemView(ItemView itemView)
    {
        itemView.InitializeItemView(MyItem);
    }
}
