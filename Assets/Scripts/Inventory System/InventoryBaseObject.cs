using System;
using UnityEngine;

public abstract class InventoryBaseObject : ScriptableObject
{
    public string SavePath;
    public Inventory Container;

    public event Action OnInventoryChanged;

    public void InvokeOnInventoryChanged()
    {
        OnInventoryChanged.Invoke();
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Container = SaveLoadManager.Load(Container, SavePath);
    }

    [ContextMenu("Save")]
    public void Save()
    {
        SaveLoadManager.Save(Container, SavePath);
    }
}
