using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPiSP_4
{
    public class PrintText : IPrint
    {
        public void Print(List<Correspondence> correspondence)
        {
            for (int i = 0; i < correspondence.Count; i++)
            {
                Console.WriteLine($"{correspondence[i].Content}");
            }
        }
    }
}
