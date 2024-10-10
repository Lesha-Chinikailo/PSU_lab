using lab_3.Interface;
using lab_3.Type;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public abstract class Ship
    {
        protected string name;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected float displacement;
        protected ShipType shipType;
        protected List<CabinCategory> cabinCategories;

        public virtual void ShowInfo()
        {
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"displacement: {displacement}");
            Console.WriteLine($"shipType: {shipType}");
            Console.WriteLine($"cabinCategories:");
            foreach( var category in cabinCategories )
            {
                Console.WriteLine(category);
            }
        }

        public CabinCategory this[int i]
        {
            get
            {
                if (i >= 0 && i < cabinCategories.Count) return (cabinCategories[i]);
                else return (cabinCategories[0]);
            }
            set
            {
                if (i >= 0 && i < cabinCategories.Count)
                {
                    cabinCategories[i] = value;
                }
                else
                {
                    cabinCategories.Add(value);
                }
            }
        }

        public string Name
        {
            get => this.name;
            set 
            { 
                this.name = value; 
            }
        }
        public float Displacement
        {
            get => this.displacement;
            set 
            { 
                this.displacement = value; 
            }
        }
        public void setShipType(ShipType shipType)
        {
            this.shipType = shipType;
        }
        public ShipType getShipType()
        {
            return this.shipType;
        }
        public void setCabinCategories(List<CabinCategory> cabinCategories)
        {
            this.cabinCategories = cabinCategories;
        }
        public List<CabinCategory> getCabinCategories()
        {
            return this.cabinCategories;
        }
        public void AddCabinCategory(CabinCategory cabinCategory)
        {
            this.cabinCategories.Add(cabinCategory);
        }
    }
}
