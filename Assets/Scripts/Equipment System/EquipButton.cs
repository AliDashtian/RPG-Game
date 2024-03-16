using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public EquipinigMiddleManObject EquipinigMiddleMan;

    private InventorySlot MyItem;
    private ItemView MyItemView;

    private void OnEnable()
    {     
        GetComponent<Button>().onClick.AddListener(EquipingDesicsion);
        MyItemView = GetComponent<ItemView>();
    }

    void EquipOrDequip()
    {
        MyItem = MyItemView.InventorySlot;

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

    void EquipingDesicsion()
    {
        MyItem = MyItemView.InventorySlot;

        if (EquipinigMiddleMan.CurrentItem.IsInitialized())  // is the selected slot full
        {
            if (MyItem.Item.Id == EquipinigMiddleMan.CurrentItem.Item.Id)  // if the selected equipment is the same as selected slot
            {
                DequipButton();
            }
            else if (!MyItem.BeingCarried)
            {
                Swap();
            }
        }
        else  // if the selected slot is empty
        {
            if (!MyItem.BeingCarried)
            {
                EquipButtonFunction();
            }
        }
    }

    void EquipButtonFunction()
    {
        //if (MyItem.BeingCarried)
        //{
        //    DequipButton();
        //}

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
