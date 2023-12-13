using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameEquipmetRow : EquipmentRow
{
    public KeyCode NextItemInput;

    private int CurrentItemIndex = 0;

    public override void InitializeRowItems()
    {
        ClearSlot();

        for (int i = 0; i < ThisRow.Container.Items.Count; i++) 
        {
            if (ThisRow.Container.HasItem(i))
                CreateAndInitializeSlots(i);
        }

        ShowCurrentItem();
    }

    void CreateAndInitializeSlots(int id)
    {
        EquipmentSlot slot = Instantiate(EquipmentSlotPrefab, transform);

        //EquipmentObjectInfo objectInfo = new EquipmentObjectInfo(id, ThisRow);

        slot.InitializeSlot(id, ThisRow);
        Slots.Add(slot);
    }

    void ShowCurrentItem()
    {
        if (Slots.Count <= 0)
            return;

        foreach (var slot in Slots)
        {
            slot.gameObject.SetActive(false);
        }

        Slots[CurrentItemIndex].gameObject.SetActive(true);
    }

    void ShowNextItem()
    {
        CurrentItemIndex++;

        if (CurrentItemIndex >= Slots.Count)
        {
            CurrentItemIndex = 0;
        }

        ShowCurrentItem();
    }

    private void Update()
    {
        if (Input.GetKeyDown(NextItemInput))
        {
            ShowNextItem();
        }
    }

    void ClearSlot()
    {
        foreach (var item in Slots)
        {
            Destroy(item.gameObject);
        }

        Slots.Clear();
    }
}
