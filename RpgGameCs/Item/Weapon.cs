namespace RpgGameCs.Item;

public abstract class Weapon : Tool
{
    public override uint HarvestStrength { get; }
    public override string DisplayName { get; }
    public override short Durability { get; }
    public override uint MaxStackSize { get; }
    public override Material MaterialType { get; }

    protected Weapon(string displayName, short durability, Material materialType,uint maxStackSize = 1, uint harvestStrength = 0)
    {
        HarvestStrength = harvestStrength;
        DisplayName = displayName;
        Durability = durability;
        MaxStackSize = maxStackSize;
        MaterialType = materialType;
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