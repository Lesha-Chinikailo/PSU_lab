using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_1.tasks
{
    public static class Task1
    {
        public static void run()
        {
            program1();
            program3TestCharArAndString();
            program4TestStringBuilder();
            program5TestSinglePat();
            program7();
            program8();

        }

        public static void program1()
        {
            string[] firstNames = { "Саша", "Маша", "Олег", "Света", "Игорь" };
            Console.WriteLine("Here is the array:");
            for (int i = 0; i < firstNames.Length; i++)
                Console.WriteLine(firstNames[i] + "\t");
            Console.WriteLine("\n");
            Array.Reverse(firstNames);
            for (int i = 0; i < firstNames.Length; i++)
                Console.WriteLine(firstNames[i] + "\t");
            Console.WriteLine("\n");
            Console.WriteLine("Cleared out all but one...");
            Array.Clear(firstNames, 1, 4);
            for (int i = 0; i < firstNames.Length; i++)
                Console.WriteLine(firstNames[i] + "\t\n");
        }

        public static void PrintAr(string name, Array A)
        {
            Console.WriteLine(name);
            switch (A.Rank)
            {
                case 1:
                    for (int i = 0; i < A.GetLength(0); i++)
                        Console.Write("\t" + name + "[{0}]={1}", i, A.GetValue(i));
                    Console.WriteLine();
                    break;
            
                case 2:
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        for (int j = 0; j < A.GetLength(1); j++)
                            Console.Write("\t" + name + "[{0},{1}]={2}", i, j,
                            A.GetValue(i, j));
                        Console.WriteLine();
                    }
                    break;
                default: break;
            }
        }

        public static string CharArrayToString(char[] ar)
        {
            string result = "";
            for (int i = 0; i < ar.Length; i++) result += ar[i];
            return (result);
        }
        public static void PrintCharAr(string name, char[] ar)
        {
            Console.WriteLine(name);
            for (int i = 0; i < ar.Length; i++) Console.Write(ar[i]);
            Console.WriteLine();
        }
        public static void program3TestCharArAndString()
        {
            string hello = "Здравствуй, Мир!";
            char[] strM1 = hello.ToCharArray();
            PrintCharAr("strM1", strM1);
            char[] World = new char[3];
            Array.Copy(strM1, 12, World, 0, 3); //копирование подстроки
            PrintCharAr("World", World);
            Console.WriteLine(CharArrayToString(World));
        }

        public static void program4TestStringBuilder()
        {
            StringBuilder s1 = new StringBuilder("ABC"),
            s2 = new StringBuilder("CDE"), s3 = new StringBuilder();
            s3 = s1.Append(s2);
            bool b1 = (s1 == s3);
            char ch1 = s1[0], ch2 = s2[0];
            Console.WriteLine("s1={0}, s2={1}, b1={2}," + "ch1={3}, ch2 ={4}", s1,s2,b1,ch1,ch2);
            StringBuilder s = new StringBuilder("Zenon");
            s[0] = 'L'; 
            Console.WriteLine(s);
        }


        static string FindMatch(string str, string strpat)
        {
            Regex pat = new Regex(strpat);
            Match match = pat.Match(str);
            string found = "";
            if (match.Success)
            {
                found = match.Value;
                Console.WriteLine("Строка ={0}\tОбразец={1}\t Найдено ={2}", str,strpat,found);
            }
            return (found);
        }
        public static void program5TestSinglePat()
        {
            string str, strpat, found;
            Console.WriteLine("Поиск по образцу");
            //образец задает подстроку, начинающуюся с символа a,
            //далее идут буквы или цифры.
            str = "start"; strpat = @"a\w+";
            found = FindMatch(str, strpat); //art
            str = "fab77cd efg";
            found = FindMatch(str, strpat); //ab77cd
                                            //образец задает подстроку, начинающуюся с символа a,
                                            //заканчивающуюся f с возможными символами b и d в середине
            strpat = "a(b|d)*f"; str = "fabadddbdf";
            found = FindMatch(str, strpat);//adddbdf


            //program 5
            Console.WriteLine("око и рококо");
            strpat = "око"; str = "рококо";
            FindMatches(str, strpat);
        }

        static void FindMatches(string str, string strpat)
        {
            Regex pat = new Regex(strpat);
            MatchCollection match = pat.Matches(str);
            Console.WriteLine("Строка ={0}\tОбразец={1}\tНайдено ={2}", str,strpat,match.Count);
        }

        public static void program7()
        {
            string si = "Это строка для поиска";
            // найти любой пробельный символ следующий за непробельным
            Regex theReg = new Regex(@"(\S+)\s");
            // получить коллекцию результата поиска
            MatchCollection theMatches = theReg.Matches(si);
            // перебор всей коллекции
            foreach (Match theMatch in theMatches)
            {
                Console.WriteLine("theMatch.Length: {0}", theMatch.Length);
                if (theMatch.Length != 0)
                    Console.WriteLine("theMatch: {0}", theMatch.ToString());
            }
        }


        public static void program8()
        {
            string stringl = "04:03:27 127.0.0.0 GotDotNet.ru";
            Regex theReg = new Regex(@"(?<время>(\d|\:)+)\s" +
            @"(?<ip>(\d|\.)+)\s" + @"(?<url>\S+)");

            // группа time – одна и более цифр или двоеточий, за которыми следует пробельный символ

            // группа ip адрес – одна и более цифр или точек, за которыми следует пробельный символ
 
            // группа url – один и более непробельных символов
            MatchCollection theMatches = theReg.Matches(stringl);
            foreach (Match theMatch in theMatches)
            {
                if (theMatch.Length != 0)
                {
                    // выводим найденную подстроку
                    Console.WriteLine("\ntheMatch: {0}", theMatch.ToString());
                    // выводим группу "time"
                    Console.WriteLine("время: {0}", theMatch.Groups["время"]);
                    // выводим группу "ip"
                    Console.WriteLine("ip: {0}", theMatch.Groups["ip"]);
                    // выводим группу "url"
                    Console.WriteLine("url: {0}", theMatch.Groups["url"]);
                }
            }
        }
    }
}
