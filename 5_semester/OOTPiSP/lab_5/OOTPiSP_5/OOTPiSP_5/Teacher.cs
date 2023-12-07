using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPiSP_5
{
    public class Teacher : IObserver
    {
        public string Name { get; set; }
        IObservable magazine;
        public Teacher(string name, IObservable obs)
        {
            this.Name = name;
            Subscribe(obs);
        }
        public void Update(string changes)
        {
            Console.Write(changes);
            Console.WriteLine($"\tfor {Name}\n");
        }
        public void Unsubscribe()
        {
            if (magazine == null)
                return;
            magazine.RemoveObserver(this);
            magazine.NotifyObservers($"{Name} unsubscribed");
            magazine = null;
        }
        public void Subscribe(IObservable obs)
        {
            if (magazine != null)
                return;
            magazine = obs;
            magazine.RegisterObserver(this);
            magazine.NotifyObservers($"{Name} signed up");
        }

        public void ShowItemAt(int indexItem)
        {
            if (magazine == null)
                return;
            Console.WriteLine($"{Name} receive: {magazine.GetItemAt(indexItem)}\n");
        }
    }
}
