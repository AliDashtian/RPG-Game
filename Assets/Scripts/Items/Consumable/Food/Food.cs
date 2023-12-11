using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Food")]
public class Food : ConsumableItem
{
    private void Awake()
    {
        ConsumableType = ConsumableTypes.Food;
    }
}
