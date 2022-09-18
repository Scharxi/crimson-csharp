using RpgGameCs.Enchantments;

namespace RpgGameCs.Item;

public class EnchantableWrapperDelegate<T> : IEnchantable
{
    private readonly List<Enchantment> _enchantments;

    public EnchantableWrapperDelegate()
    {
        _enchantments = new List<Enchantment>(); 
    }
    
    public List<Enchantment> GetEnchantments()
    {
        return _enchantments;
    }

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

    // typeof(ITest).IsAssignableFrom(typeof(A))
    public bool IsValidEnchantment(Enchantment enchantment)
    {
        return enchantment.GetValidTargets().Any(ench => ench.IsAssignableFrom(typeof(T)));
    }
}