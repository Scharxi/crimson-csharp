using RpgGameCs.Entity.Item;
using RpgGameCs.Item;

namespace RpgGameCs.Inventory;

public abstract class PlayerInventory : AbstractInventory
{
    public abstract ArmorPiece?[] ArmorContents { get; set; }
    public ArmorPiece? Helmet { get; set; }
    public ArmorPiece? Boots { get; set; }
    public ArmorPiece? Leggings { get; set; }
    public ArmorPiece? ChestPlate { get; set; }
    public IItem? ItemInHand { get; set; }

    public IInventoryHolder Holder { get; set; }

    protected PlayerInventory(IInventoryHolder holder)
    {
        Holder = holder;
    }
}