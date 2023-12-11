using UnityEngine;

[System.Serializable]
public class Item
{
    public int Id;
    public string Name;
    public int Level;

    [HideInInspector]
    public bool IsStackable;

    public Item(ItemObject itemObject)
    {
        Id = itemObject.Id;
        Name = itemObject.Name;
        Level = itemObject.Level;
        IsStackable = itemObject.IsStackable;
    }
}
