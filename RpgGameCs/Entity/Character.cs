namespace RpgGameCs.Entity;

public abstract class Character : ILivingEntity
{
    protected Character? _killer;
    protected int _lastDamage;
    protected uint _health;
    protected uint _absorptionAmount;
    protected uint _maxHealth;

    protected Character(uint health, uint absorptionAmount, uint maxHealth)
    {
        _health = health;
        _absorptionAmount = absorptionAmount;
        _maxHealth = maxHealth;
    }

    public abstract void Damage(uint damage);
    public abstract void Damage(uint amount, ILivingEntity source);
    
    public uint GetAbsorptionAmount() => _absorptionAmount;

    public uint GetHealth() => _health;

    public uint GetMaxHealth() => _maxHealth; 

    public void SetAbsorptionAmount(uint amount)
    {
        _absorptionAmount = amount; 
    }

    public void SetMaxHealth(uint maxHealth)
    {
        _maxHealth = maxHealth; 
    }

    public void SetHealth(uint health)
    {
        _health = health; 
    }

    public void kill(IEntity? killer)
    {
        if (killer == null)
            _killer = null;
        _killer = (Character?)killer!;
        SetHealth(0);
        SetLastDamage(Math.Abs((int)GetMaxHealth()));
    }

    public void heal()
    {
        throw new NotImplementedException();
    }

    public void Attack(IEntity target)
    {
        throw new NotImplementedException();
    }

    public int GetLastDamage() => _lastDamage; 

    public void SetLastDamage(int amount)
    {
        _lastDamage = amount; 
    }

    public Character? GetKiller() => _killer;

    public bool CanPickupItems() => true;
}