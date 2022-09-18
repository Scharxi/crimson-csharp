using RpgGameCs.Enchantments;
using RpgGameCs.Entity.Item;
using RpgGameCs.Item.Tools;
using RpgGameCs.Item.Weapons;

namespace RpgTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IsToolTest()
    {
        var pickaxe = new DiamondPickaxe();
        Assert.That(IItem.IsTool(pickaxe), Is.EqualTo(true));
    }

    [Test]
    public void TestIfEnchantmentIsValidForItem()
    {
        var pickaxe = new DiamondPickaxe();
        Assert.That(pickaxe.IsValidEnchantment(Enchantment.Durability), Is.EqualTo(true));
        Assert.That(pickaxe.IsValidEnchantment(Enchantment.Sharpness), Is.EqualTo(false));
    }

    [Test]
    public void TestCreateDiamondSword()
    {
        var sword = new DiamondSword();
        Assert.That(sword.DisplayName, Is.EqualTo("Diamond Sword"));
        Assert.That(sword.IsWeapon(), Is.True);
        Assert.That(sword.IsTool(), Is.False);
        
        Assert.That(sword.Damage, Is.EqualTo(14));
    }

    [Test]
    public void GetSharpnessOfDiamondSwordTest()
    {
        var sword = new DiamondSword();
        Assert.That(sword.GetSharpness(), Is.EqualTo(2));
    }
}