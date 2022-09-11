namespace RpgGameCs.Entity;

public interface IDamageable
{
    void Damage(uint damage);
    void Damage(uint amount, ILivingEntity source);

    uint GetAbsorptionAmount();
    uint GetHealth();
    uint GetMaxHealth();

    void SetAbsorptionAmount(uint amount);
    void SetMaxHealth(uint maxHealth);
    void SetHealth(uint health);
}