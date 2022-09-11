using RpgGameCs.Entity;

namespace RpgGameCs.Class;

public class Warrior : Character, IClass
{
    public Warrior() : base(40, 10, 40)
    {
    }

    public override void Damage(uint damage)
    {
        throw new NotImplementedException();
    }

    public override void Damage(uint amount, ILivingEntity source)
    {
        throw new NotImplementedException();
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