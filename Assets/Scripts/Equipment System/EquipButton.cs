using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public EquipinigMiddleManObject EquipinigMiddleMan;

    private InventorySlot MyItem;

    private void OnEnable()
    {     
        GetComponent<Button>().onClick.AddListener(EquipOrDequip);
    }

    void EquipOrDequip()
    {
        MyItem = GetComponent<ItemView>().InventorySlotView;

        if (MyItem.BeingCarried)
            DequipButton();
        else
            EquipButtonFunction();
    }

    void EquipButtonFunction()
    {
        //MyItem.BeingCarried = true;
        UpdateItemView();
        EquipinigMiddleMan.Equip(MyItem);
        UpdateItemView();
    }

    void DequipButton()
    {
        EquipinigMiddleMan.Dequip(MyItem);
        UpdateItemView();
    }

    private void UpdateItemView()
    {
        GetComponent<ItemView>().InitializeItemView(MyItem);
    }
}
