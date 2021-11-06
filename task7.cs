using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace task__1
{
    [TestFixture]
    class task7
    {
        public string GetIPv4(uint number)
        {
            var ipv4 = new List<string>();
            var divider = (uint)(Math.Pow(2, 8));
            for (int i = 0; i < 4; i++)
            {
                ipv4.Insert(0, (number % divider).ToString());
                number /= divider;
            }
            return String.Join('.', ipv4);
        }

        [Test]
        public void Test1()
        {
            uint list = 0;
            var expected = "0.0.0.0";
            var result = GetIPv4(list);
            Assert.AreEqual(expected, result);

        }
        [Test]
        public void Test2()
        {
            uint list = 2149583361;
            var expected = "128.32.10.1";
            var result = GetIPv4(list);
            Assert.AreEqual(expected, result);

        }
        [Test]
        public void Test3()
        {
            uint list = 32;
            var expected = "0.0.0.32";
            var result = GetIPv4(list);
            Assert.AreEqual(expected, result);

        }


    }
}
