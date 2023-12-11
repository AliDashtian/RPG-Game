using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/Bow/Crossbow")]
public class Crossbow : Bow
{

    private void Awake()
    {
        BowType = BowTypes.Crossbow;
    }
}
