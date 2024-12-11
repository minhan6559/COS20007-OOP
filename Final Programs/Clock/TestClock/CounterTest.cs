using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestCounter
{
    [TestFixture]
    public class CounterTest
    {
        [Test]
        public void TestInitializeCounter()
        {
            Counter a = new Counter("A");
            Assert.That(a.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void TestIncrement()
        {
            Counter a = new Counter("A");
            a.Increment();
            Assert.That(a.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void TestIncrementMultiple()
        {
            Counter a = new Counter("A");
            for (int i = 0; i < 3; i++)
            {
                a.Increment();
            }
            Assert.That(a.Ticks, Is.EqualTo(3));
        }

        [Test]
        public void TestReset()
        {
            Counter a = new Counter("A");
            a.Increment();
            a.Reset();
            Assert.That(a.Ticks, Is.EqualTo(0));
        }
    }
}