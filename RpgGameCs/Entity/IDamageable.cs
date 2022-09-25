namespace RpgGameCs.Entity;

/// <summary>
/// Represents an Entity that has health and can take damage.
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// Deals the given amount of damage to this entity.
    /// </summary>
    /// <param name="damage">Amount of damage to deal</param>
    void Damage(uint damage);

    /// <summary>
    /// Deals the given amount of damage to this entity, from a specified entity.
    /// </summary>
    /// <param name="amount">Amount of damage to deal</param>
    /// <param name="source">Entity which to attribute this damage from</param>
    void Damage(uint amount, ILivingEntity source);

    /// <summary>
    /// Gets the entity's absorption amount.
    /// </summary>
    /// <returns>absorption amount from 0</returns>
    uint GetAbsorptionAmount();

    /// <summary>
    /// Gets the entity's health from 0 to getMaxHealth(), where 0 is dead.
    /// </summary>
    /// <returns>Health represented from 0 to max</returns>
    uint GetHealth();

    /// <summary>
    /// Gets the maximum health this entity has.
    /// </summary>
    /// <returns>Maximum health</returns>
    uint GetMaxHealth();

    /// <summary>
    /// Sets the entity's absorption amount.
    /// </summary>
    /// <param name="amount">new absorption amount from 0</param>
    void SetAbsorptionAmount(uint amount);

    /// <summary>
    /// <para>Sets the maximum health this entity can have.</para>
    /// <para>If the health of the entity is above the value provided it will be set to that value.</para>
    /// </summary>
    /// <param name="maxHealth">amount of health to set the maximum to</param>
    void SetMaxHealth(uint maxHealth);

    /// <summary>
    /// Sets the entity's health from 0 to getMaxHealth(), where 0 is dead.
    /// </summary>
    /// <param name="health">New health represented from 0 to max</param>
    void SetHealth(uint health);
}