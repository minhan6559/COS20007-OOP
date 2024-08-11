using NUnit.Framework;
using ClockProgram;

namespace TestClock
{
    [TestFixture]
    public class ClockTest
    {
        [TestCase]
        public void TestInitializeClock()
        {
            Clock clock = new Clock();
            Assert.That(clock.Time, Is.EqualTo("00:00:00"));
        }

        [TestCase]
        public void TestTick()
        {
            Clock clock = new Clock();
            clock.Tick();
            Assert.That(clock.Time, Is.EqualTo("00:00:01"));
        }

        [Test]
        public void TestTickMultiple()
        {
            Clock clock = new Clock();
            for (int i = 0; i < 3; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.Time, Is.EqualTo("00:00:03"));
        }

        [Test]
        public void TestTickMinutes()
        {
            Clock clock = new Clock();
            for (int i = 0; i < 60; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.Time, Is.EqualTo("00:01:00"));
        }

        [Test]
        public void TestTickHours()
        {
            Clock clock = new Clock();
            for (int i = 0; i < 3600; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.Time, Is.EqualTo("01:00:00"));
        }

        [Test]
        public void TestTickHalfDay()
        {
            Clock clock = new Clock();
            for (int i = 0; i < 43200; i++)
            {
                clock.Tick();
            }
            Assert.That(clock.Time, Is.EqualTo("00:00:00"));
        }
    }
}