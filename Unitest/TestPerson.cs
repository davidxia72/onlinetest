using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitest
{
    [TestFixture]
    class TestPerson
    {
        [Test]
        public void TestFullName()
        {

            Person person = new Person();
            person.Lname = "";
            person.Mname = "Roe";
            person.Fname = "John";

            string actual = person.GetFullName();
            string expected = "John Roe Doe";
            Assert.AreEqual(expected, actual,
        "The GetFullName returned a different Value");
        }
    }
}
