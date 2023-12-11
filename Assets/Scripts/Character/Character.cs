using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character/Character")]
public class Character : ScriptableObject
{
    public StatsObject CharacterStats;
    public InventoryObject CharacterInventory;

}
