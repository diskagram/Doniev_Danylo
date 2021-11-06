using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace task__1
{
    [TestFixture]
    class task4
    {

        static int getPairsCount(int[] arr, int sum)
        {

            int count = 0;


            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if ((arr[i] + arr[j]) == sum)
                        count++;

            return count;
        }


        [Test]
        public void Test1()
        {
            int[] arr = { 1, 3, 6, 2, 2, 0, 4, 5 };
            int list = 5;
            var expected = 4;
            var result = getPairsCount(arr, list);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test2()
        {
            int[] arr = { 1, 3, 6, 1 };
            int list = 5;
            var expected =0;
            var result = getPairsCount(arr, list);
            Assert.AreEqual(expected, result);


        }
        [Test]
        public void Test3()
        {
            int[] arr = { 1, 3, 5, -1 };
            int list = 4;
            var expected =2;
            var result = getPairsCount(arr, list);
            Assert.AreEqual(expected, result);

        }
    }
}
