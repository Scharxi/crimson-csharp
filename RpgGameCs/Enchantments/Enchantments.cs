using RpgGameCs.Entity.Item;
using RpgGameCs.Item;

namespace RpgGameCs.Enchantments;


internal sealed class SharpnessEnchantment : Enchantment
{
    public override int GetStartLevel()
    {
        return 1; 
    }

    public override int GetMaxLevel()
    {
        return 5;
    }

    public override IEnumerable<Type> GetValidTargets()
    {
       return new[] { typeof(Weapon) };
    }
}

internal sealed class DurabilityEnchantment : Enchantment
{
    public override IEnumerable<Type> GetValidTargets()
    {
        return new[] { typeof(Tool), typeof(Weapon) };
    }

    public override int GetStartLevel()
    {
        return 1;
    }

    public override int GetMaxLevel()
    {
        return 3;
    }
}