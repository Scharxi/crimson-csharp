using RpgGameCs.Inventory;

namespace RpgGameCs.Entity;

public interface ILivingEntity : IEntity, IDamageable, IInventoryHolder
{
    void Kill(IEntity? killer);
    void Heal();
    bool Attack(IEntity target);
    int GetLastDamage();
    void SetLastDamage(int amount);
    Character? GetKiller();
    bool CanPickupItems(); 
}