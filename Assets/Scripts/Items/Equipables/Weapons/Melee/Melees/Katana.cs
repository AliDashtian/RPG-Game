using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/Melee/Katana")]
public class Katana : Melee
{
    private void Awake()
    {
        MeleeType = MeleeTypes.Katana;
    }
}
