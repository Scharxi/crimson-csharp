﻿namespace RpgGameCs.Item.Weapons;

public abstract class Sword : Weapon
{
    protected abstract uint Sharpness { get; set; }

    protected Sword(uint damage,uint sharpness, short durability, string displayName, Material material) : base(displayName, durability, material, damage * sharpness)
    {
        Sharpness = sharpness;
    }
}