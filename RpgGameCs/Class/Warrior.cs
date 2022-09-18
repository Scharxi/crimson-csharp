using System.Diagnostics;
using RpgGameCs.Entity;

namespace RpgGameCs.Class;

public class Warrior : Character, IClass
{
    public Warrior() : base(40, 10, 40)
    {
    }

    public override void Damage(uint damage)
    {
        Health -= damage;
        LastDamage += (int) damage;
    }

    public override void Damage(uint amount, ILivingEntity source)
    {
        Damage(amount);
        LastDamageDealer = source;
    }

    public string GetClassName()
    {
        return "Warrior";
    }

    public Stats.Stats GetStats()
    {
        throw new NotImplementedException();
    }
}