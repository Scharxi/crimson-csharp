using RpgGameCs.Enchantments;

namespace RpgGameCs.Item;

public interface IEnchantable
{
    List<Enchantment> GetEnchantments();
    void AddEnchantment(Enchantment enchantment);
    bool RemoveEnchantment(Enchantment enchantment);
    bool IsEnchanted();

    bool IsValidEnchantment(Enchantment enchantment);
}