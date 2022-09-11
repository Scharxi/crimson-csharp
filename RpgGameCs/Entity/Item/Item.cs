using RpgGameCs.Item;

namespace RpgGameCs.Entity.Item;

public interface IItem : IEntity
{
    string DisplayName { get; }
    short Durability { get; }
    uint MaxStackSize { get; }
    Material MaterialType { get; }

    bool IsTool();

    bool IsWeapon();

    static bool IsTool(IItem item)
    {
        return item is Tool;
    }

    static bool IsWeapon(IItem item)
    {
        return item is Weapon;
    }
}