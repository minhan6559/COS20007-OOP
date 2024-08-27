namespace TestBag;
using SwinAdventure;

public class Tests
{
    private Bag _b1;
    private Bag _b2;
    private Item _item1;
    private Item _item2;

    [SetUp]
    public void Setup()
    {
        _b1 = new Bag(new string[] { "bag1" }, "Bag 1", "A huge bag");
        _b2 = new Bag(new string[] { "bag2" }, "Bag 2", "A small bag");

        _item1 = new Item(new string[] { "shovel" }, "Shovel", "A shovel");
        _b1.Inventory.Put(_item1);

        _item2 = new Item(new string[] { "sword" }, "Sword", "A sword");
        _b2.Inventory.Put(_item2);

        _b1.Inventory.Put(_b2);
    }

    [Test]
    public void TestBagLocateItem()
    {
        Assert.AreEqual(_item1, _b1.Locate("shovel"));
        Assert.IsTrue(_b1.Inventory.HasItem("shovel"));
    }

    [Test]
    public void TestBagLocateItself()
    {
        Assert.AreEqual(_b1, _b1.Locate("bag1"));
    }

    [Test]
    public void TestBagLocateNothing()
    {
        Assert.IsNull(_b1.Locate("axe"));
    }

    [Test]
    public void TestBagFullDescription()
    {
        Assert.AreEqual("In the Bag 1 you can see:\n\tShovel (shovel)\n\tBag 2 (bag2)", _b1.FullDescription);
    }

    [Test]
    public void TestBagInBag()
    {
        Assert.AreEqual(_b2, _b1.Locate("bag2"));
        Assert.AreEqual(_item1, _b1.Locate("shovel"));
        Assert.IsNull(_b1.Locate("sword"));
    }

    [Test]
    public void TestBagHasPriviledgeItem()
    {
        Item item = new Item(new string[] { "axe" }, "Axe", "An axe");
        item.PrivilegeEscalation("4794");
        _b2.Inventory.Put(item);
        Assert.IsNull(_b1.Locate("12"));
    }
}
