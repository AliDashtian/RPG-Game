using UnityEngine;

public class ItemViewInfo
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Sprite Sprite { get; private set; }
    public int StackSize { get; private set; }
    public bool BeingCarried { get; private set; }

    public ItemViewInfo(string name, string description, Sprite sprite, int stackSize, bool beingCarried)
    {
        Name = name;
        Description = description;
        Sprite = sprite;
        StackSize = stackSize;
        BeingCarried = beingCarried;
    }
}
