using RpgGameCs.Entity;

namespace RpgGameCs.Item;

public abstract class Weapon : Tool, IDamageDealer
{
    public override uint HarvestStrength { get; }
    public override string DisplayName { get; }
    public override short Durability { get; }
    public override uint MaxStackSize { get; }
    public override Material MaterialType { get; }
    public uint Damage { get; set; }

    protected Weapon(string displayName, short durability, Material materialType, uint damage, uint maxStackSize = 1,
        uint harvestStrength = 0)
    {
        HarvestStrength = harvestStrength;
        DisplayName = displayName;
        Durability = durability;
        MaxStackSize = maxStackSize;
        MaterialType = materialType;
        Damage = damage;
    }

    public override bool IsTool()
    {
        return false;
    }

    public override bool IsWeapon()
    {
        return true;
    }
}