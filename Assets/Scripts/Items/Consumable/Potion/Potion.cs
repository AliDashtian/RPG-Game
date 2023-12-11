using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Potion")]
public class Potion : ConsumableItem
{
    private void Awake()
    {
        ConsumableType = ConsumableTypes.Potion;
    }
}
