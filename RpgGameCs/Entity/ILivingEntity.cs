namespace RpgGameCs.Entity;

public interface ILivingEntity : IEntity, IDamageable
{
    void kill(IEntity? killer);
    void heal();
    void Attack(IEntity target);
    int GetLastDamage();
    void SetLastDamage(int amount);
    Character? GetKiller();
    bool CanPickupItems(); 
}