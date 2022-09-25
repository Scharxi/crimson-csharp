namespace RpgGameCs.Entity;

/// <summary>
/// Represents an entity that can deal damage
/// </summary>
public interface IDamageDealer
{
    public uint Damage { get; set; }
}