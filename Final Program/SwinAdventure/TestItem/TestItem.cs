using SwinAdventure;

namespace TestItem
{
    public class Tests
    {
        private Item _item;
        [SetUp]
        public void Setup()
        {
            _item = new Item(new string[] { "sword" }, "a sharp sword", "A sharp sword for cutting things");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_item.AreYou("sword"));
            Assert.IsFalse(_item.AreYou("axe"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.That(_item.ShortDescription, Is.EqualTo("a sharp sword (sword)"));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(_item.FullDescription, Is.EqualTo("A sharp sword for cutting things"));
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            _item.PrivilegeEscalation("4794");
            Assert.That(_item.FirstId, Is.EqualTo("12"));
        }
    }
}