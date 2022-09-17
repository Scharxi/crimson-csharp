using RpgGameCs.Enchantments;
using RpgGameCs.Entity.Item;
using RpgGameCs.Inventory;

namespace RpgGameCs.Item;

public enum ArmorPieceType
{
    Helmet,
    Boots,
    ChestPlate,
    Leggings
}

public abstract class ArmorPiece : IEquipable, IEnchantable, IItem
{
    public ArmorPieceType PieceType { get; }

    private List<Enchantment> _enchantments = new();

    public virtual List<Enchantment> GetEnchantments()
    {
        return _enchantments;
    }

    public virtual void AddEnchantment(Enchantment enchantment)
    {
        _enchantments.Add(enchantment);
    }

    public virtual bool RemoveEnchantment(Enchantment enchantment)
    {
        return _enchantments.Remove(enchantment);
    }

    public virtual bool IsEnchanted()
    {
        return _enchantments.Count > 0;
    }

    public virtual bool IsValidEnchantment(Enchantment enchantment)
    {
        return enchantment.GetValidTargets().Any(ench => ench.IsAssignableFrom(GetType()));
    }


    public string DisplayName { get; }
    public short Durability { get; }
    public uint MaxStackSize { get; }
    public Material MaterialType { get; }

    protected ArmorPiece(string displayName, short durability, Material materialType, ArmorPieceType type,
        uint maxStackSize = 1)
    {
        DisplayName = displayName;
        Durability = durability;
        MaxStackSize = maxStackSize;
        MaterialType = materialType;
        PieceType = type;
    }


    public bool IsTool()
    {
        return false;
    }

    public bool IsWeapon()
    {
        return false;
    }

    public abstract void Equip(ref PlayerInventory inv);
    public abstract void UnEquip(ref PlayerInventory inv);

    public override bool Equals(object? obj)
    {
        if (obj is not ArmorPiece piece)
            return false;

        return piece.PieceType == PieceType;
    }

    protected bool Equals(ArmorPiece other)
    {
        return PieceType == other.PieceType;
    }

    public override int GetHashCode()
    {
        return (int)PieceType;
    }

    public class Boots : ArmorPiece
    {
        public Boots(string displayName, short durability, Material materialType,
            uint maxStackSize = 1) : base(displayName, durability, materialType, ArmorPieceType.Boots, maxStackSize)
        {
        }

        public override void Equip(ref PlayerInventory inv)
        {
            inv.Boots = this;
        }

        public override void UnEquip(ref PlayerInventory inv)
        {
            inv.Boots = null;
        }
    }

    public class Helmet : ArmorPiece
    {
        public override void Equip(ref PlayerInventory inv)
        {
            inv.Helmet = this;
        }

        public Helmet(string displayName, short durability, Material materialType, uint maxStackSize = 1) : base(
            displayName, durability, materialType, ArmorPieceType.Helmet, maxStackSize)
        {
        }

        public override void UnEquip(ref PlayerInventory inv)
        {
            inv.Helmet = null;
        }
    }

    public class ChestPlate : ArmorPiece
    {
        public override void Equip(ref PlayerInventory inv)
        {
            inv.ChestPlate = this;
        }

        public ChestPlate(string displayName, short durability, Material materialType, uint maxStackSize = 1) : base(
            displayName, durability, materialType, ArmorPieceType.ChestPlate, maxStackSize)
        {
        }

        public override void UnEquip(ref PlayerInventory inv)
        {
            inv.ChestPlate = null;
        }
    }

    public class Leggings : ArmorPiece
    {
        public Leggings(string displayName, short durability, Material materialType, uint maxStackSize = 1) : base(
            displayName, durability, materialType, ArmorPieceType.Leggings, maxStackSize)
        {
        }

        public override void Equip(ref PlayerInventory inv)
        {
            inv.Leggings = this;
        }

        public override void UnEquip(ref PlayerInventory inv)
        {
            inv.Leggings = null;
        }
    }
}