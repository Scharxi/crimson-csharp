namespace RpgGameCs.Item.Weapons;

public sealed class DiamondSword : Sword
{
    public DiamondSword(string displayName = "Diamond Sword") : base(7,2, 255, displayName, Material.DiamondSword)
    {
        DisplayName = displayName;
    }

    public override string DisplayName { get; }

}