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
            Assert.AreEqual("a sharp sword (sword)", _item.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("A sharp sword for cutting things", _item.FullDescription);
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            _item.PrivilegeEscalation("4794");
            Assert.AreEqual("12", _item.FirstId);
        }
    }
}