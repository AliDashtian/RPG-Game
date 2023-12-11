using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/Bow/NormaBow")]
public class NormalBow : Bow
{

    private void Awake()
    {
        BowType = BowTypes.NormalBow;
    }
}
