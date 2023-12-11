using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/Melee/Axe")]
public class Axe : Melee
{

    private void Awake()
    {
        MeleeType = MeleeTypes.Axe;
    }
}
