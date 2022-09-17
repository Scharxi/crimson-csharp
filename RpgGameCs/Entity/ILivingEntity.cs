namespace RpgGameCs.Entity;

public interface ILivingEntity : IEntity, IDamageable
{
    void Kill(IEntity? killer);
    void Heal();
    void Attack(IEntity target);
    int GetLastDamage();
    void SetLastDamage(int amount);
    Character? GetKiller();
    bool CanPickupItems(); 
}