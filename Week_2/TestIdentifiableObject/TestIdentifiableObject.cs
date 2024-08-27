using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]
    public class TestIdentifiableObject
    {
        private IdentifiableObject _idObj;
        private IdentifiableObject _emptyIdObj;
        private IdentifiableObject _idObjWithNoStuId;

        [SetUp]
        public void SetUp()
        {
            _idObj = new IdentifiableObject(new string[] { "104844794", "Minh An", "Nguyen" });
            _emptyIdObj = new IdentifiableObject(new string[] { });
            _idObjWithNoStuId = new IdentifiableObject(new string[] { "1234", "Minh An", "Nguyen" });
        }

        [TestCase]
        public void TestAreYou()
        {
            Assert.IsTrue(_idObj.AreYou("104844794"));
            Assert.IsTrue(_idObj.AreYou("Minh An"));
        }

        [TestCase]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_idObj.AreYou("1O4844795"));
        }

        [TestCase]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_idObj.AreYou("miNh aN"));
            Assert.IsTrue(_idObj.AreYou("NgUyEn"));
        }

        [TestCase]
        public void TestFirstId()
        {
            Assert.AreEqual("104844794", _idObj.FirstId);
        }

        [TestCase]
        public void TestFirstIdWithNoId()
        {
            Assert.AreEqual("", _emptyIdObj.FirstId);
        }

        [TestCase]
        public void TestAddId()
        {
            _idObj.AddIdentifier("Andy");
            Assert.IsTrue(_idObj.AreYou("Andy"));
        }

        [TestCase]
        public void TestPrivilegeEscalation()
        {
            _idObjWithNoStuId.PrivilegeEscalation("4794");
            Assert.AreEqual("12", _idObjWithNoStuId.FirstId);
        }
    }
}