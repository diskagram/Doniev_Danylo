using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace task__1
{
    [TestFixture]
    class task3
    {
        static int DigitalRoot(long num)
        {
            while (num > 9)
            {
                num = num.ToString().ToCharArray().Sum(x => x - '0');
            }

            return (int)num;
        }

        static int digital_root(long num)
        {
            var t = DigitalRoot(num);
            return t;
        }
        [Test]
        public void Test1()
        {
            int list = 13;
            var expected = 4;
            var result = DigitalRoot(list);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test2()
        {
            int list = 177;
            var expected = 6;
            var result = DigitalRoot(list);
            Assert.AreEqual(expected, result);


        }
        [Test]
        public void Test3()
        {
            int list = 40988;
            var expected = 2;
            var result = DigitalRoot(list);
            Assert.AreEqual(expected, result);

        }
    }
}
