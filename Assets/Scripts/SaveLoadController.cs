using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
using System;
using System.Collections.Generic;

public class SaveLoadController : MonoBehaviour
{
    public StatsObject PlayerStats;
    public List<InventoryObject> Inventories;

    private void Start()
    {
        PlayerStats.Load();
        LoadInventory();
    }

    private void OnApplicationQuit()
    {
        PlayerStats.Save();
        SaveInventory();
    }

    void SaveInventory()
    {
        foreach (var item in Inventories)
        {
            item.Save();
        }
    }
    void LoadInventory()
    {
        foreach (var item in Inventories)
        {
            item.Load();
        }
    }
}
