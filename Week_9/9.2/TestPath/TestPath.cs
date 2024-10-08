using NUnit.Framework;
using SwinAdventure;
using Path = SwinAdventure.Path;

namespace TestPath
{
    public class TestPath
    {
        private Player _player;
        private Location _location1;
        private Location _location2;
        private Path _path;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Minh An", "104844794");
            _location1 = new Location("forest", "A dark forest with tall trees");
            _location2 = new Location("cave", "A dark cave with bats");
            _path = new Path(new string[] { "north" }, "north", "a path from forest to cave", _location1, _location2);
            _location1.AddPath(_path);
            _player.Location = _location1;
        }

        [Test]
        public void TestPathIsBlocked()
        {
            Assert.That(_path.IsBlocked, Is.False);
            _path.IsBlocked = true;
            Assert.That(_path.IsBlocked, Is.True);
        }

        [Test]
        public void TestPathSource()
        {
            Assert.That(_path.Source, Is.EqualTo(_location1));
        }

        [Test]
        public void TestPathDestination()
        {
            Assert.That(_path.Destination, Is.EqualTo(_location2));
        }

        [Test]
        public void TestPathLocate()
        {
            Assert.That(_player.Locate("north"), Is.EqualTo(_path));
        }

        [Test]
        public void TestPathLocateNothing()
        {
            Assert.That(_player.Locate("south"), Is.Null);
        }

        [Test]
        public void TestPathFullDescription()
        {
            Assert.That(_path.FullDescription, Is.EqualTo("a path from forest to cave"));
        }

        [Test]
        public void TestPathList()
        {
            Assert.That(_location1.PathList, Is.EqualTo("There are exits to north"));
        }

        [Test]
        public void TestPathListEmpty()
        {
            Location location = new Location("desert", "A hot desert with sand dunes");
            Assert.That(location.PathList, Is.EqualTo("There are no paths to other locations"));
        }
    }
}