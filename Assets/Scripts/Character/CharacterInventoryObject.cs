using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character/Inventory")]
public class CharacterInventoryObject : ScriptableObject
{
    // not being used but looks useful

    [Serializable]
    public struct CharacterInventory
    {
        public ItemObject Item;
        public int amount;
    }

    public List<CharacterInventory> Inventory;
}
