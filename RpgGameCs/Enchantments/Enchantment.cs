using RpgGameCs.Entity.Item;

namespace RpgGameCs.Enchantments;


public abstract class Enchantment
{
    public static readonly Enchantment Sharpness = new SharpnessEnchantment();
    public static readonly Enchantment Durability = new DurabilityEnchantment(); 
    
    public abstract int GetStartLevel();
    public abstract int GetMaxLevel();

    public abstract IEnumerable<Type> GetValidTargets();
}
