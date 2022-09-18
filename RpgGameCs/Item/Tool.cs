using System.Runtime.CompilerServices;
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

    private readonly EnchantableWrapperDelegate<Tool> _enchantableWrapperDelegate;

    protected Tool()
    {
        _enchantableWrapperDelegate = new EnchantableWrapperDelegate<Tool>(); 
    }

    public List<Enchantment> GetEnchantments()
    {
        return _enchantableWrapperDelegate.GetEnchantments();
    }

    public void AddEnchantment(Enchantment enchantment)
    {
        _enchantableWrapperDelegate.AddEnchantment(enchantment);
    }

    public bool RemoveEnchantment(Enchantment enchantment)
    {
        return _enchantableWrapperDelegate.RemoveEnchantment(enchantment);
    }

    public bool IsEnchanted()
    {
        return _enchantableWrapperDelegate.IsEnchanted();
    }

    public bool IsValidEnchantment(Enchantment enchantment)
    {
        return _enchantableWrapperDelegate.IsValidEnchantment(enchantment);
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
}