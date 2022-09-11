namespace RpgGameCs.Item.Weapons;

public abstract class Sword : Weapon
{
    public abstract uint Sharpness { get; set; }
    public override uint Damage { get; }

    protected Sword(uint damage,uint sharpness, short durability, string displayName, Material material) : base(displayName, durability, material)
    {
        Sharpness = sharpness;
        Damage = damage * sharpness;
    }
}