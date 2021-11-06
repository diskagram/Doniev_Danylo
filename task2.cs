using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace task__1
{
    [TestFixture]
    public class task2
    {

        public char first_non_repeating_letter(string input)
        {

            input = input.ToLower();
            char result = input.FirstOrDefault(ch => input.IndexOf(ch) == input.LastIndexOf(ch));
           
            return result;
        }
        [Test]
        public void Test1()
        {
            string list = "stress";
            var expected = 't';
            var result = first_non_repeating_letter(list);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test2()
        {
            string list = "Cccrrww";
            var expected = '\0';
            var result = first_non_repeating_letter(list);
            Assert.AreEqual(expected, result);

        }
        [Test]
        public void Test3()
        {
            string list = "streSS";
            var expected = 't';
            var result = first_non_repeating_letter(list);
            Assert.AreEqual(expected, result);

        }
        [Test]
        public void Test4()
        {
            string list = "cat";
            var expected = 'c';
            var result = first_non_repeating_letter(list);
            Assert.AreEqual(expected, result);

        }
    }
}


