using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public Text stackSizeText;
    public Image iconImage;
    public Image isEquipedCheckImage;

    public bool ShowBeingCarried;

    public ItemViewObject ItemViewObject;

    [HideInInspector]
    public ItemViewInfo ViewInfo;

    [HideInInspector]
    public InventorySlot InventorySlotView;

    public void InitializeItemView(InventorySlot inventorySlot)
    {
        InventorySlotView = inventorySlot;
        ViewInfo = ItemViewObject.GetItemInfo(inventorySlot);

        iconImage.enabled = true;
        iconImage.sprite = ViewInfo.Sprite;

        if (ViewInfo.StackSize > 1)
            stackSizeText.text = ViewInfo.StackSize.ToString();

        if (ShowBeingCarried && ViewInfo.BeingCarried)
            isEquipedCheckImage.gameObject.SetActive(true);

        if (!ViewInfo.BeingCarried)
            isEquipedCheckImage.gameObject.SetActive(false);

    }

    public void ClearItemView()
    {
        iconImage.enabled = false;
        iconImage.sprite = null;

        isEquipedCheckImage.gameObject.SetActive(false);
    }
}
