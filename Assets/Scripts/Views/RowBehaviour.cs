using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RowBehaviour : MonoBehaviour
{
    public InventoryBaseObject TargetInventory;

    public abstract void InitializeRowItems();
    public abstract void AddRowItems();

    public virtual void ReInitializeRow()
    {
        AddRowItems();
        InitializeRowItems();
    }

    private void OnEnable()
    {
        TargetInventory.OnInventoryChanged += ReInitializeRow;
    }

    private void OnDisable()
    {
        TargetInventory.OnInventoryChanged -= ReInitializeRow;
    }
}
