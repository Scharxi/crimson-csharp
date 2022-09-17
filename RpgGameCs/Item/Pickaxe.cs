using RpgGameCs.Inventory;

namespace RpgGameCs.Item;

public abstract class Pickaxe : Tool
{
    public sealed override string DisplayName { get; }

    public sealed override short Durability { get; }
    public sealed override uint Damage { get; }
    public override uint MaxStackSize => 1;
    public sealed override Material MaterialType { get; }
    public sealed override uint HarvestStrength { get; }

    protected Pickaxe(short durability, uint damage, Material material, uint harvestStrength, string displayName = "Pickaxe")
    {
        Durability = durability;
        Damage = damage;
        MaterialType = material;
        HarvestStrength = harvestStrength;
        DisplayName = displayName;
    }
}


