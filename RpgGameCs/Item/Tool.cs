using RpgGameCs.Enchantments;
using RpgGameCs.Entity.Item;
using RpgGameCs.Inventory;

namespace RpgGameCs.Item;

public abstract class Tool : IItem, IEnchantable, IEquipable
{
    public abstract uint Damage { get; }
    public abstract uint HarvestStrength { get; }
    public abstract string DisplayName { get; }
    public abstract short Durability { get; }
    public abstract uint MaxStackSize { get; }
    public abstract Material MaterialType { get; }

    private List<Enchantment> _enchantments = new();

    List<Enchantment> IEnchantable.GetEnchantments() => _enchantments;

    public void AddEnchantment(Enchantment enchantment)
    {
        if (!IsValidEnchantment(enchantment))
            throw new ArgumentException("Enchantment cannot be applied to this item.");
        _enchantments.Add(enchantment);
    }

    public bool RemoveEnchantment(Enchantment enchantment)
    {
        return _enchantments.Remove(enchantment);
    }

    public bool IsEnchanted()
    {
        return _enchantments.Count > 0; 
    }

    public virtual bool IsTool()
    {
        return true;
    }

    public virtual bool IsWeapon()
    {
        return false;
    }
    
    public virtual void Equip(ref PlayerInventory inv)
    {
        inv.ItemInHand = this; 
    }

    public virtual void UnEquip(ref PlayerInventory inv)
    {
        inv.ItemInHand = null; 
    }

    // typeof(ITest).IsAssignableFrom(typeof(A))
    public bool IsValidEnchantment(Enchantment enchantment)
    {
        return enchantment.GetValidTargets().Any(ench => ench.IsAssignableFrom(GetType()));
    }
}