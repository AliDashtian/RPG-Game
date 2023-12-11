using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/Melee/Sword")]
public class Sword : Melee
{
    private void Awake()
    {
        MeleeType = MeleeTypes.Sword;
    }
}
