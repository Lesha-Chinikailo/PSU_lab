using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPiSP_5
{
    public interface IObserver
    {
        void Update(string changes);

        void ShowItemAt(int indexItem);
    }
}
