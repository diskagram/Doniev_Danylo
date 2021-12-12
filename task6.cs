using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace task__1
{
    [TestFixture]
    class task6
    {
        static void swap(char[] ar, int i, int j)
        {
            char temp = ar[i];
            ar[i] = ar[j];
            ar[j] = temp;
        }

        static int findNext(int re)
        {
            string num = re.ToString();
            char[] ar = new char[num.Length];
            for (var j = 0; j < num.Length; j++)
            {
                ar[j] = num[j];
            }

            int n = ar.Length;
            int i;
            for (i = n - 1; i > 0; i--)
            {
                if (ar[i] > ar[i - 1])
                {
                    break;
                }
            }

            if (i == 0)
            {
                int array1 = -1;
                return array1;
            }
            else
            {
                int x = ar[i - 1], min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (ar[j] > x && ar[j] < ar[min])
                    {
                        min = j;
                    }
                }

                swap(ar, i - 1, min);
                Array.Sort(ar, i, n - i);
                string s = new string(ar);
                int bar = Int32.Parse(s);
                return bar;
            }
        }


        [Test]
        public void Test1()
        {

            var words = 12;
            var result = findNext(words);
            var expected =21;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test2()
        {

            var words = 21;
            var result = findNext(words);
            var expected = -1;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test3()
        {

            var words = 2017;
            var result = findNext(words);
            var expected = 2071;

            Assert.AreEqual(expected, result);
        }
    }
}
