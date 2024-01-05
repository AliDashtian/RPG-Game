using UnityEngine;

public class PlayerInitialSetup : MonoBehaviour
{
    public Player Player;

    private Character _character;

    public void SelectCharacter(Character character)
    {
        _character = character;

        CopyCharacterToPlayer();
    }

    private void CopyCharacterToPlayer()
    {
        CopyCharacterInventoryToPlayer();
        CopyCharacterStatsToPlayer();

        Player.Character = _character;
    }

    void CopyCharacterInventoryToPlayer()
    {
        for (int i = 0; i < _character.CharacterInventory.Container.Items.Count; i++)
        {
            Item item = _character.CharacterInventory.Container.Items[i].Item;
            int amount = _character.CharacterInventory.Container.Items[i].StackSize;

            Player.PlayerInventory.AddItem(item, amount);
        }
    }

    void CopyCharacterStatsToPlayer()
    {
        Player.PlayerStats.Stats = _character.CharacterStats.Stats;
    }
}
