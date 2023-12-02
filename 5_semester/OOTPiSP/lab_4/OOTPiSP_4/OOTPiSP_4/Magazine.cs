using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPiSP_4
{
    class Magazine
    {
        private List<Correspondence> correspondence = new List<Correspondence>() {
            new Correspondence(0, "Correspondence 0"),
            new Correspondence(1, "Correspondence 1"),
            new Correspondence(2, "Correspondence 2"),
            new Correspondence(3, "Correspondence 3"),
            new Correspondence(4, "Correspondence 4"),
        };
        public Magazine(IPrint printer)
        {
            Printer = printer;
        }
        public IPrint Printer { private get; set; }
        public void Print()
        {
            Printer.Print(correspondence);
        }
    }
}
