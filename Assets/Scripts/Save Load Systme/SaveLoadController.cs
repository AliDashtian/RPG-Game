using UnityEngine;
using System.Collections.Generic;

public class SaveLoadController : MonoBehaviour
{
    public CharacterStatsObject PlayerStats;
    public List<InventoryBaseObject> Inventories;

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

    //void skj()
    //{
    //    Attribute[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes().ToArray();

    //    foreach (Attribute attr in attributes)
    //    {
    //        switch (attr)
    //        {
    //            case SaveLoadAttribute sla:
    //                Debug.Log(sla.ToString());
    //                break;
    //        }
    //    }
    //}

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
