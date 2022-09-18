using System.Diagnostics;
using RpgGameCs.Class;
using RpgGameCs.Item.Weapons;

namespace RpgTests;

public class CharacterTests
{
    private Warrior _warrior = null!;
    
    [SetUp]
    public void SetUp()
    {
        _warrior = new Warrior();
    }

    [Test]
    public void HealCharacterTest()
    {
        _warrior.SetHealth(_warrior.GetHealth() - 10);
        Assert.That(_warrior.GetHealth(), Is.EqualTo(30));
        _warrior.Heal();
        Assert.That(_warrior.GetHealth(), Is.EqualTo(_warrior.GetMaxHealth()));
    }

    [Test]
    public void DealingDamageTest()
    {
        var dealer = new Warrior(); 
        _warrior.Damage(5, dealer);
        Assert.That(_warrior.GetLastDamage(), Is.EqualTo(5));
        Assert.That(_warrior.GetLastDamageDealer(), Is.EqualTo(dealer));
    }
    
    
    [Test]
    public void AttackOtherEntityTest()
    {
        var target = new Warrior();
        var weapon = new DiamondSword();
        _warrior.GetEquipment().ItemInHand = weapon;
        Assert.That(_warrior.GetEquipment().ItemInHand, Is.EqualTo(weapon));
        Assert.That(_warrior.Attack(target), Is.True);
        Assert.That(target.GetLastDamageDealer(), Is.EqualTo(_warrior));
    }
}