using RpgGameCs.Class;
using RpgGameCs.Item.Armor;
using RpgGameCs.Item.Tools;
using RpgGameCs.Item.Weapons;

namespace RpgTests;

public class InventoryTests
{
    private Warrior _warrior;

    [SetUp]
    public void SetUp()
    {
        _warrior = new Warrior();
    }

    [Test]
    public void CreateInventoryTest()
    {
        Assert.That(_warrior.GetInventory().IsEmpty(), Is.True);
    }

    [Test]
    public void AddItemToInventoryTest()
    {
        var inventory = _warrior.GetInventory();
        var pickaxe = new DiamondPickaxe();
        inventory.SetItem(1, pickaxe);
        Assert.Multiple(() =>
        {
            Assert.That(inventory.IsEmpty(), Is.False);
            Assert.That(inventory.GetItem(1), Is.EqualTo(pickaxe));
        });
    }

    [Test]
    public void IterationOverInventoryTest()
    {
        var inventory = _warrior.GetInventory();
        var pickaxe = new DiamondPickaxe();
        inventory.SetItem(1, pickaxe);
        foreach (var item in inventory)
        {
            Assert.That(pickaxe, Is.EqualTo(item));
        }
    }

    [Test]
    public void GetInventoryOfCharacterTest()
    {
        var warrior = new Warrior();
        Assert.That(warrior.GetInventory().IsEmpty(), Is.True);
        warrior.GetInventory().SetItem(1, new DiamondPickaxe());
        Assert.That(warrior.GetInventory().IsEmpty(), Is.False);
        warrior.GetInventory().Clear();
        Assert.That(warrior.GetInventory().IsEmpty(), Is.True);
    }

    [Test]
    public void SetBootsOfWarriorTest()
    {
        var inv = _warrior.GetEquipment();
        var boots = new GoldBoots();
        boots.Equip(ref inv);
        Assert.Multiple(() =>
        {
            Assert.That(inv.ArmorContents, Is.Not.Empty);
            Assert.That(inv.Boots, Is.EqualTo(boots));
        });
    }

    [Test]
    public void EquipToolAndWeaponTest()
    {
        var inv = _warrior.GetEquipment();
        var sword = new DiamondSword();
        var pickaxe = new DiamondPickaxe();
        sword.Equip(ref inv);
        Assert.That(inv.ItemInHand, Is.EqualTo(sword));
        pickaxe.Equip(ref inv);
        Assert.That(inv.ItemInHand, Is.EqualTo(pickaxe));
    }
}