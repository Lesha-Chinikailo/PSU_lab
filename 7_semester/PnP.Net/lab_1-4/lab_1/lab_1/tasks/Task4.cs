using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_1.tasks
{
    public static class Task4
    {
        public static void run(string str)
        {
            Console.WriteLine("emails до:");
            Console.WriteLine(str);
            Regex regex = new Regex(@"[a-zA-Z0-9\.]+@[a-zA-Z]+.[a-zA-Z]+");

            MatchCollection matches = regex.Matches(str);

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine(match.ToString());
            //}

            Console.WriteLine("emails после:");

            matches.ToList().ForEach(match => Console.WriteLine(match + "\n"));
        }

        private static void checkEveryString(string str, Regex regex)
        {
            List<string> strs = str.Split(' ').ToList();
            for (int i = 0; i < strs.Count; i++)
            {
                Console.WriteLine(strs[i]);
                if (regex.Match(strs[i]).Success)
                {
                    Console.WriteLine("yes");
                }
                else { Console.WriteLine("no"); }
                Console.WriteLine();
            }
        }
    }
}





// @"([a-zA-Z0-9]|.)+@(gmail|mail|pdu|students.psu).(com|ru|by)"