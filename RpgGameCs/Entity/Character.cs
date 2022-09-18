using RpgGameCs.Inventory;

namespace RpgGameCs.Entity;
/// <summary>
/// Base Class of all entities that can be "played" by the user.
/// </summary>
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

    /// <inheritdoc />
    public uint GetAbsorptionAmount() => _absorptionAmount;

    /// <inheritdoc />
    public uint GetHealth() => Health;

    /// <inheritdoc />
    public uint GetMaxHealth() => _maxHealth;

    /// <inheritdoc />
    public void SetAbsorptionAmount(uint amount)
    {
        _absorptionAmount = amount;
    }

    /// <inheritdoc />
    public ILivingEntity? GetLastDamageDealer() => LastDamageDealer;

    /// <inheritdoc />
    public void SetMaxHealth(uint maxHealth)
    {
        _maxHealth = maxHealth;
    }

    /// <inheritdoc />
    public void SetHealth(uint health)
    {
        Health = health;
    }

    /// <inheritdoc />
    public void Kill(IEntity? killer)
    {
        if (killer == null)
            _killer = null;
        _killer = (Character?)killer!;
        SetHealth(0);
        SetLastDamage(Math.Abs((int)GetMaxHealth()));
    }

    /// <inheritdoc />
    public void Heal()
    {
        SetHealth(GetMaxHealth());
    }

    /// <inheritdoc />
    public bool Attack(IEntity target)
    {
        if (target is not ILivingEntity entity) return false;
        if (GetEquipment().ItemInHand is not IDamageDealer) return false;
        
        entity.Damage(((IDamageDealer)GetEquipment().ItemInHand!).Damage, this);
        return true;
    }

    /// <inheritdoc />
    public int GetLastDamage() => LastDamage;

    /// <inheritdoc />
    public void SetLastDamage(int amount)
    {
        LastDamage = amount;
    }

    /// <inheritdoc />
    public Character? GetKiller() => _killer;

    /// <inheritdoc />
    public bool CanPickupItems() => true;

    public IInventory GetInventory()
    {
        return _inventory;
    }

    /// <inheritdoc />
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