using RpgGameCs.Inventory;

namespace RpgGameCs.Entity;

/// <summary>
/// Represents a living entity, such as a character or a creature
/// </summary>
public interface ILivingEntity : IEntity, IDamageable, IInventoryHolder
{
    /// <summary>
    /// Kills the entity
    /// </summary>
    /// <param name="killer">The killer, null if the entity was killed manually</param>
    void Kill(IEntity? killer);

    /// <summary>
    /// Sets the health of the entity back to max health
    /// </summary>
    void Heal();

    /// <summary>
    /// <para>Deals damage to the specified target. </para>
    /// <para>The damage to be inflicted on the target is derived from the damage of the item in the character's hand. </para>
    /// </summary>
    /// <param name="target">The target to attack</param>
    /// <returns>true whether the target has successfully dealt damage from the character</returns>
    bool Attack(IEntity target);
    
    /// <summary>
    /// Returns the amount of the last damage suffered 
    /// </summary>
    /// <returns>the amount of the last damage suffered</returns>
    int GetLastDamage();
    /// <summary>
    /// Sets the last dealt damage to the specified amount
    /// </summary>
    /// <param name="amount">the amount to set</param>
    void SetLastDamage(int amount);
    /// <summary>
    /// <para>Returns the character that killed the entity.</para>
    /// </summary>
    /// <returns>the character or null if the entity has been killed manually</returns>
    Character? GetKiller();
    /// <summary>
    /// Determines whether the entity can pickup items or not
    /// </summary>
    /// <returns>true if the entity can pickup items, false otherwise</returns>
    bool CanPickupItems();
}