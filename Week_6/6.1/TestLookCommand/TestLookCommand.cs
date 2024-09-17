using SwinAdventure;

namespace TestLookCommand
{
    public class TestLookCommand
    {
        private Player _player;
        private LookCommand _look;
        private Item _gem;
        private Bag _bag;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Minh An Nguyen", "Student ID: 104844794");
            _look = new LookCommand();
            _gem = new Item(new string[] { "gem" }, "a gem", "a shiny gem");
            _bag = new Bag(new string[] { "bag" }, "a bag", "a small bag");
        }

        [Test]
        public void TestLookAtMe()
        {
            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            string expected = "You are Minh An Nguyen, Student ID: 104844794\n" +
                                "You are carrying:\n" +
                                "\ta bag (bag)";
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "inventory" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(_gem);

            string expected = "a shiny gem";
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtUnkown()
        {
            string expected = "I can't find the gem";
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(_gem);

            string expected = "a shiny gem";
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);

            string expected = "a shiny gem";
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            string expected = "I can't find the bag";
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _player.Inventory.Put(_bag);

            string expected = "I can't find the gem";
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That(_look.Execute(_player, new string[] { "look", "around" }), Is.EqualTo("I don't know how to look like that"));
            Assert.That(_look.Execute(_player, new string[] { "hello", "104844794" }), Is.EqualTo("I don't know how to look like that"));
            Assert.That(_look.Execute(_player, new string[] { "hello", "Minh", "An" }), Is.EqualTo("Error in look input"));
            Assert.That(_look.Execute(_player, new string[] { "look", "this", "bag" }), Is.EqualTo("What do you want to look at?"));
            Assert.That(_look.Execute(_player, new string[] { "look", "at", "bag", "inside", "inventory" }), Is.EqualTo("What do you want to look in?"));
        }
    }
}