using RpgGameCs.Item;

namespace RpgGameCs.Inventory;

public class CharacterInventory : PlayerInventory
{
    private ArmorPiece?[] _armor;

    public override ArmorPiece?[] ArmorContents
    {
        get => _armor;
        set => _armor = value.ToArray();
    }

    public CharacterInventory(IInventoryHolder holder) : base(holder)
    {
        _armor = new[] { Helmet, ChestPlate, Leggings, Boots };
    }
}