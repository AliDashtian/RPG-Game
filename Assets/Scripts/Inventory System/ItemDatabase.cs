using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Database")]
public class ItemDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;

    private Dictionary<int, ItemObject> ItemsDictionary = new Dictionary<int, ItemObject>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].Id = i;
            ItemsDictionary.Add(i, Items[i]);
        }
    }

    public ItemObject GetItem(int key)
    {
        return ItemsDictionary[key];
    }

    public void OnBeforeSerialize()
    {
        ItemsDictionary = new Dictionary<int, ItemObject>();
    }
}
