using System.Collections.Generic;
using UnityEngine;

public class EquipmentRow : MonoBehaviour
{
    public EquipmentObject ThisRow;
    public EquipmentSlot EquipmentSlotPrefab;

    internal List<EquipmentSlot> Slots = new List<EquipmentSlot>();

    private void Start()
    {
        FindRowItems();
        InitializeRowItems();
    }

    private void OnEnable()
    {
        ThisRow.OnInventoryChanged += InitializeRowItems;
    }

    private void OnDisable()
    {
        ThisRow.OnInventoryChanged -= InitializeRowItems;
    }

    void FindRowItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Slots.Add(transform.GetChild(i).GetComponent<EquipmentSlot>());
        }
    }

    public virtual void InitializeRowItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //EquipmentObjectInfo objectInfo = new EquipmentObjectInfo(i, ThisRow);

            Slots[i].InitializeSlot(i, ThisRow);
        }
    }
}
