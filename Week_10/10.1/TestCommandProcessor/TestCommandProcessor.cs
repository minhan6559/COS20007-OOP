using SwinAdventure;
using Path = SwinAdventure.Path;

namespace TestCommandProcessor
{
    public class TestCommandProcessor
    {
        private CommandProcessor _cmdProcessor;
        private Player _player;
        private Location _location1;
        private Location _location2;
        private Path _path;
        private Item _sword;
        private Bag _bag;


        [SetUp]
        public void Setup()
        {
            _cmdProcessor = new CommandProcessor();
            _player = new Player("Minh An", "104844794");
            _location1 = new Location("forest", "A dark forest with tall trees");
            _location2 = new Location("cave", "A dark cave with bats");
            _path = new Path(new string[] { "north" }, "north", "a path from forest to cave", _location1, _location2);
            _location1.AddPath(_path);
            _player.Location = _location1;
            _sword = new Item(new string[] { "sword" }, "a sword", "a steel sword");
            _bag = new Bag(new string[] { "bag" }, "a bag", "a leather bag");
            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_bag);
        }

        [Test]
        public void TestLookAtMe()
        {
            string expected = "You are Minh An, 104844794\n" +
                                "You are carrying:\n" +
                                "\ta sword (sword)\n\ta bag (bag)";
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "look", "at", "inventory" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtSword()
        {
            string expected = "a steel sword";
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "look", "at", "sword" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtUnkown()
        {
            string expected = "I can't find the gem";
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "look", "at", "gem" }), Is.EqualTo(expected));
        }

        [Test]
        public void TestMoveToNonExistentPath()
        {
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "go", "south" }), Is.EqualTo("I can't find the path to south"));
        }

        [Test]
        public void TestMoveToDestination()
        {
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "go", "north" }), Is.EqualTo("You have moved to cave"));
        }

        [Test]
        public void TestInvalidMoveCommand()
        {
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "move", "north" }), Is.EqualTo("You have moved to cave"));
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "go", "north", "to" }), Is.EqualTo("Where do you want to go?"));
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "go", "north", "to", "cave" }), Is.EqualTo("I don't know how to move like that"));
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "go", "north", "to", "cave", "now" }), Is.EqualTo("I don't know how to move like that"));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "look", "around" }), Is.EqualTo("I don't know how to look like that"));
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "look", "this", "bag" }), Is.EqualTo("What do you want to look at?"));
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "look", "at", "bag", "inside", "inventory" }), Is.EqualTo("What do you want to look in?"));
        }

        [Test]
        public void TestInvalidCommand()
        {
            Assert.That(_cmdProcessor.Execute(_player, new string[] { "hi", "hey" }), Is.EqualTo("I don't know how to do that"));
        }
    }
}