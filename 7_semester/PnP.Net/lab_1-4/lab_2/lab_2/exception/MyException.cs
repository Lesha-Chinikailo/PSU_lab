using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.exception
{
    public class MyException : Exception
    {
        public MyException(string? message) : base(message)
        {
        }
    }
}
