using RpgGameCs.Enchantments;
using RpgGameCs.Item;
using RpgGameCs.Item.Tools;

namespace RpgTests;

public class EnchantmentTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void TestIfWeaponEnchantmentIsApplyableToTool()
    {
        var pickaxe = new DiamondPickaxe();
        Assert.Throws<ArgumentException>(() => pickaxe.AddEnchantment(Enchantment.Sharpness));
    }

    [Test]
    public void TestValidEnchantments()
    {
        Assert.That(new[] { typeof(Tool), typeof(Weapon) }, Is.EqualTo(Enchantment.Durability.GetValidTargets()));
    }

    [Test]
    public void AddEnchantmentToTool()
    {
        var pickaxe = new DiamondPickaxe();
        pickaxe.AddEnchantment(Enchantment.Durability);
        Assert.That(pickaxe.IsEnchanted(), Is.EqualTo(true));
    }

    [Test]
    public void TestRemovingEnchantmentFromTool()
    {
        var pickaxe = new DiamondPickaxe();
        pickaxe.AddEnchantment(Enchantment.Durability);
        Assert.That(pickaxe.RemoveEnchantment(Enchantment.Durability), Is.EqualTo(true));
    }
}