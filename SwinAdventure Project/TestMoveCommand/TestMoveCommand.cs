using NUnit.Framework;
using SwinAdventure;
using Path = SwinAdventure.Path;

namespace TestMoveCommand
{
    public class TestMoveCommand
    {
        private Player _player;
        private Location _location1;
        private Location _location2;
        private Path _path;
        private MoveCommand _moveCommand;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Minh An", "104844794");
            _location1 = new Location("forest", "A dark forest with tall trees");
            _location2 = new Location("cave", "A dark cave with bats");
            _path = new Path(new string[] { "north" }, "north", "a path from forest to cave", _location1, _location2);
            _location1.AddPath(_path);
            _player.Location = _location1;
            _moveCommand = new MoveCommand();
        }

        [Test]
        public void TestMoveToBlockedPath()
        {
            _path.IsBlocked = true;
            Assert.That(_moveCommand.Execute(_player, new string[] { "go", "north" }), Is.EqualTo("The path to north is blocked"));
        }

        [Test]
        public void TestMoveToNonExistentPath()
        {
            Assert.That(_moveCommand.Execute(_player, new string[] { "go", "south" }), Is.EqualTo("I can't find the path to south"));
        }

        [Test]
        public void TestMoveToDestination()
        {
            Assert.That(_moveCommand.Execute(_player, new string[] { "go", "north" }), Is.EqualTo("You have moved to cave"));
        }

        [Test]
        public void TestInvalidMoveCommand()
        {
            Assert.That(_moveCommand.Execute(_player, new string[] { "move", "north" }), Is.EqualTo("You have moved to cave"));
            Assert.That(_moveCommand.Execute(_player, new string[] { "go", "north", "to" }), Is.EqualTo("Where do you want to go?"));
            Assert.That(_moveCommand.Execute(_player, new string[] { "go", "north", "to", "cave" }), Is.EqualTo("I don't know how to move like that"));
            Assert.That(_moveCommand.Execute(_player, new string[] { "go", "north", "to", "cave", "now" }), Is.EqualTo("I don't know how to move like that"));
        }
    }
}