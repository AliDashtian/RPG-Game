using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/Melee/Dagger")]
public class Dagger : Melee
{
    private void Awake()
    {
        MeleeType = MeleeTypes.Dagger;
    }
}
