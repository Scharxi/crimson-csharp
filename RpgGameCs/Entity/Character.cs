using RpgGameCs.Inventory;
using RpgGameCs.Item;

namespace RpgGameCs.Entity;

public abstract class Character : ILivingEntity, IEquipmentHolder
{
    protected Character? Killer;
    protected int LastDamage;
    protected uint Health;
    protected uint AbsorptionAmount;
    protected uint MaxHealth;
    protected ILivingEntity? LastDamageDealer;

    private PlayerInventory _inventory;

    protected Character(uint health, uint absorptionAmount, uint maxHealth)
    {
        Health = health;
        AbsorptionAmount = absorptionAmount;
        MaxHealth = maxHealth;
        _inventory = new CharacterInventory(this);
        LastDamageDealer = null;
    }

    public abstract void Damage(uint damage);
    public abstract void Damage(uint amount, ILivingEntity source);

    public uint GetAbsorptionAmount() => AbsorptionAmount;

    public uint GetHealth() => Health;

    public uint GetMaxHealth() => MaxHealth;

    public void SetAbsorptionAmount(uint amount)
    {
        AbsorptionAmount = amount;
    }

    public ILivingEntity? GetLastDamageDealer() => LastDamageDealer;

    public void SetMaxHealth(uint maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(uint health)
    {
        Health = health;
    }

    public void Kill(IEntity? killer)
    {
        if (killer == null)
            Killer = null;
        Killer = (Character?)killer!;
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

    public Character? GetKiller() => Killer;

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
        uint takenDamage;
        if (AbsorptionAmount != 0)
        {
            if ((int)(AbsorptionAmount - damage) < 0)
            {
                takenDamage = Health -= damage;
                return takenDamage;
            }

            takenDamage = AbsorptionAmount - damage;
            return takenDamage;
        }
        else
        {
            takenDamage = Health -= damage;
            return takenDamage;
        }
    }
}