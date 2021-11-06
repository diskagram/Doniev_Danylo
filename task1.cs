using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace task__1
{
    [TestFixture]
    public class task1
    {
            
        public List<object> GetIntegersFromList(List<object> input) {
            var filtered = new List<object>();
            
            foreach (var word in input)
            {
                if (word is int)
                {
                    filtered.Add(word);;
                }
            }
            
            return filtered;
        }
        [Test]
        public void Test1()
        {
            var list = new List<object>() { "sky", 3, "rock", "forest", "new",
    "falcon", "jewelry" };
            var expected = new List<object>() {3 };
            var result = GetIntegersFromList(list);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test2()
        {
            var list = new List<object>() { 1, 2, 'a', 'b', 0, 15 };
            var expected = new List<object>() { 1, 2, 0, 15 };
            var result = GetIntegersFromList(list);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test3()
        {
            var list = new List<object>() { 1, 2, 'a', 'b', "aasf", '1', "123", 231 };
            var expected = new List<object>() { 1, 2, 231 };
            var result = GetIntegersFromList(list);
            Assert.AreEqual(expected, result);
        }
    }
}
    

