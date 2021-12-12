using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace task__1
{


    [TestFixture]
    class task5
    {
        static string friends(string words)
        {
            if (words.Length == 0) { return ""; }
            string[] subs = words.Split(";");
            List<string> all = new List<string>();
            List<string> all2 = new List<string>();
            var allpersons = new List<string>();
            foreach (var sub in subs)
            {
                string[] ns = sub.Split(":");
                var namesurname = string.Join(',', ns[1].ToUpper(), ns[0].ToUpper());
                all.Add(namesurname);
            }

            all.Sort();
            foreach (var sub in all)
            {
                string[] ns = sub.Split(",");
                var namesurname = string.Join(',', ns[1].ToUpper(), ns[0].ToUpper());
                all2.Add(namesurname);
            }
            var result = String.Join(" | ", all2.ToArray());
            return result;
        }

        [Test]
        public void Test1()
        {

            var words = "Fired:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            var result = friends(words);
            var expected = "ALFRED,CORWILL | FIRED,CORWILL | RAPHAEL,CORWILL | WILFRED,CORWILL | BARNEY,TORNBULL | BETTY,TORNBULL | BJON,TORNBULL";
 
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test2()
        {

            var words = "";
            var result = friends(words);
            var expected = "";

            Assert.AreEqual(expected, result);
        }




    }
}
