using System.Collections.Generic;
using UnityEngine;

public class EquipmentRow : RowBehaviour
{
    public EquipmentView EquipmentSlotPrefab;

    internal List<EquipmentView> Slots = new List<EquipmentView>();

    private void Start()
    {
        AddRowItems();
        InitializeRowItems();
    }

    public override void ReInitializeRow()
    {
        base.ReInitializeRow();
    }

    public override void AddRowItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Slots.Add(transform.GetChild(i).GetComponent<EquipmentView>());
        }
    }

    public override void InitializeRowItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Slots[i].InitializeSlot(i, TargetInventory);
        }
    }
}
