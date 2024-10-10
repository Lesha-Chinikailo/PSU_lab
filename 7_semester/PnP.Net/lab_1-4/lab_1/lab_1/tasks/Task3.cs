using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1.tasks
{
    public static class Task3
    {
        public static void run(string str)
        {
            string[] words = str.Split(' ');
            StringBuilder sb = new StringBuilder();
            if (words.Length == 0)
                return;
            string temp = words[0];
            sb.Append(temp);
            sb.Append(' ');
            for (int i = 1; i < words.Length; i++)
            {
                if (!compareWords(temp, words[i])){
                    sb.Append(words[i]);
                    sb.Append(' ');
                    temp = words[i];
                }
            }
            Console.WriteLine("строка после:");
            Console.WriteLine(sb.ToString());
        }

        static bool compareWords(string str1, string str2)
        {
            return str1 == str2;
        }
    }
}
