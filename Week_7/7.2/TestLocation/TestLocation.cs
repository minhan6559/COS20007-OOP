using SwinAdventure;
using NUnit.Framework;

namespace TestLocation
{
    public class TestLocation
    {
        private Location _location;
        private Item _item1;
        private Item _item2;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Minh An", "104844794");
            _location = new Location("forest", "A dark forest with tall trees");
            _player.Location = _location;

            _item1 = new Item(new string[] { "rock" }, "a rock", "a big rock");
            _item2 = new Item(new string[] { "flower" }, "a flower", "a red flower");
            _location.Inventory.Put(_item1);
            _location.Inventory.Put(_item2);
        }

        [Test]
        public void LocationLocateItself()
        {
            Assert.That(_location.Locate("location"), Is.EqualTo(_location));
        }

        [Test]
        public void LocationLocateItem()
        {
            Assert.That(_location.Locate("rock"), Is.EqualTo(_item1));
            Assert.That(_location.Locate("flower"), Is.EqualTo(_item2));
        }

        [Test]
        public void LocationLocateNothing()
        {
            Assert.That(_location.Locate("nothing"), Is.Null);
        }

        [Test]
        public void LocationFullDescription()
        {
            Assert.That(_location.FullDescription, Is.EqualTo("You are in the forest.\nA dark forest with tall trees\n" +
                                                               "In this location, you can see:\n" +
                                                               "\ta rock (rock)\n" +
                                                               "\ta flower (flower)"));
        }

        [Test]
        public void PlayerLocateItemInLocation()
        {
            Assert.That(_player.Locate("rock"), Is.EqualTo(_item1));
            Assert.That(_player.Locate("flower"), Is.EqualTo(_item2));
        }
    }
}