using RpgGameCs.Class;
using RpgGameCs.Inventory;
using RpgGameCs.Item.Tools;

namespace RpgTests;

public class InventoryTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void CreateInventoryTest()
    {
        var inventory = new CharacterInventory();
        Assert.That(inventory.IsEmpty(), Is.True);
    }

    [Test]
    public void AddItemToInventoryTest()
    {
        var inventory = new CharacterInventory();
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
        var inventory = new CharacterInventory();
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
}