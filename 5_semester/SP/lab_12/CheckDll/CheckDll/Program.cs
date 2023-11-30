using System;
using lab_12;

namespace CheckDll;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(MyMath.Addition(4, 5));
        Console.WriteLine(StringWork.ToUpper("hello"));
        Console.WriteLine(StringWork.ToLower("TITLE"));
    }
}