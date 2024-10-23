using SwinAdventure;

namespace TestPlayer
{
    public class Tests
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Minh An", "an AI enthusiast");
            _player.Inventory.Put(new Item(new string[] { "sword" }, "a sharp sword", "A sharp sword for cutting things"));
            _player.Inventory.Put(new Item(new string[] { "axe" }, "a blunt axe", "A blunt axe for bludgeoning things"));
        }

        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.That(_player.Locate("sword")!.AreYou("sword"), Is.True);
            Assert.IsTrue(_player.Locate("axe")!.AreYou("axe"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.IsTrue(_player.Locate("me")!.AreYou("me"));
            Assert.IsTrue(_player.Locate("inventory")!.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.IsNull(_player.Locate("dagger"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string expected = "You are Minh An, an AI enthusiast\n" +
                                "You are carrying:\n" +
                                "\ta sharp sword (sword)\n" +
                                "\ta blunt axe (axe)";
            Assert.That(_player.FullDescription, Is.EqualTo(expected));
        }
    }
}