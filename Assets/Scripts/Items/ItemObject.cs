using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    [Header("ItemDescription")]
    public int Id;
    public ItemTypes ItemType;
    public string Name;
    [TextArea(5, 15)]
    public string Description;
    public bool IsStackable;
    public Sprite Sprite;
    public int Level;
}
