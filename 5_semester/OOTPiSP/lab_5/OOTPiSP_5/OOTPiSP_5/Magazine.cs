using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPiSP_5
{
    public class Magazine : IObservable
    {

        List<IObserver> observers;

        List<Correspondence> correspondence;
        public Magazine()
        {
            observers = new List<IObserver>();
            correspondence = new List<Correspondence>
        {
            new Correspondence(0, "Correspondence 0"),
            new Correspondence(1, "Correspondence 1"),
            new Correspondence(2, "Correspondence 2"),
            new Correspondence(3, "Correspondence 3"),
            new Correspondence(4, "Correspondence 4"),
        };
        }
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(string changes)
        {
            foreach (IObserver o in observers)
            {
                o.Update(changes);
            }
        }

        public string GetItemAt(int indexItem)
        {
            return correspondence[indexItem].Content;
        }

    }
}
