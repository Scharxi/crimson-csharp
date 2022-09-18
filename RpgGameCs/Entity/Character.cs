using RpgGameCs.Inventory;
using RpgGameCs.Item;

namespace RpgGameCs.Entity;

public abstract class Character : ILivingEntity, IEquipmentHolder
{
    private Character? _killer;
    protected int LastDamage;
    protected uint Health;
    private uint _absorptionAmount;
    private uint _maxHealth;
    protected ILivingEntity? LastDamageDealer;

    private readonly PlayerInventory _inventory;

    protected Character(uint health, uint absorptionAmount, uint maxHealth)
    {
        Health = health;
        _absorptionAmount = absorptionAmount;
        _maxHealth = maxHealth;
        _inventory = new CharacterInventory(this);
        LastDamageDealer = null;
    }

    public abstract void Damage(uint damage);
    public abstract void Damage(uint amount, ILivingEntity source);

    public uint GetAbsorptionAmount() => _absorptionAmount;

    public uint GetHealth() => Health;

    public uint GetMaxHealth() => _maxHealth;

    public void SetAbsorptionAmount(uint amount)
    {
        _absorptionAmount = amount;
    }

    public ILivingEntity? GetLastDamageDealer() => LastDamageDealer;

    public void SetMaxHealth(uint maxHealth)
    {
        _maxHealth = maxHealth;
    }

    public void SetHealth(uint health)
    {
        Health = health;
    }

    public void Kill(IEntity? killer)
    {
        if (killer == null)
            _killer = null;
        _killer = (Character?)killer!;
        SetHealth(0);
        SetLastDamage(Math.Abs((int)GetMaxHealth()));
    }

    public void Heal()
    {
        SetHealth(GetMaxHealth());
    }

    public bool Attack(IEntity target)
    {
        if (target is not ILivingEntity entity) return false;
        if (GetEquipment().ItemInHand is not IDamageDealer) return false;
        
        entity.Damage(((IDamageDealer)GetEquipment().ItemInHand!).Damage, this);
        return true;
    }

    public int GetLastDamage() => LastDamage;

    public void SetLastDamage(int amount)
    {
        LastDamage = amount;
    }

    public Character? GetKiller() => _killer;

    public bool CanPickupItems() => true;

    public IInventory GetInventory()
    {
        return _inventory;
    }

    public PlayerInventory GetEquipment() => (PlayerInventory)GetInventory();

    /// <summary>
    /// Returns the calculated damage
    /// </summary>
    /// <returns></returns>
    protected uint TakeDamage(uint damage)
    {
        throw new NotImplementedException();
    }
}