using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
    public class MyMath
    {
        public static int Addition(int a, int b)
        {
            int result = 0;
            for(int i = 0; i < b; i++)
            {
                result += a;
            }
            return b < 0 ? -result : result;
        }
    }
    public class StringWork
    {
        public static string ToUpper(string str)
        {
            return str.ToUpper(); 
        }
        public static string ToLower(string str)
        {
            return str.ToLower();
        }
    }
}
