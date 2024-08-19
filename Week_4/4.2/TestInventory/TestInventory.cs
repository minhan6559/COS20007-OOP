using NuGet.Frameworks;
using SwinAdventure;

namespace TestInventory
{
    public class Tests
    {
        private Inventory _inventory;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _inventory.Put(new Item(new string[] { "sword" }, "a sharp sword", "A sharp sword for cutting things"));
            _inventory.Put(new Item(new string[] { "axe" }, "a blunt axe", "A blunt axe for bludgeoning things"));
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(_inventory.HasItem("sword"));
            Assert.IsTrue(_inventory.HasItem("axe"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(_inventory.HasItem("dagger"));
        }

        [Test]
        public void TestFetchItem()
        {
            Item item = _inventory.Fetch("sword")!;
            Assert.IsTrue(item.AreYou("sword"));
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [Test]
        public void TestTakeItem()
        {
            Item item = _inventory.Take("axe")!;
            Assert.IsTrue(item.AreYou("axe"));
            Assert.IsFalse(_inventory.HasItem("axe"));
        }

        [Test]
        public void TestItemList()
        {
            string expected = "\ta sharp sword (sword)\n\ta blunt axe (axe)";
            Assert.AreEqual(expected, _inventory.ItemList);
        }
    }
}