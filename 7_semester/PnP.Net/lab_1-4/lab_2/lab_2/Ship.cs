using lab_2.Interface;
using lab_2.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public abstract class Ship
    {
        protected string name;
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
        { //индексатор
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
        public override string ToString()
        {
            string categories = string.Empty;
            for (int i = 0; i < cabinCategories.Count; i++)
            {
                categories += cabinCategories[i].ToString();
                if (i != cabinCategories.Count - 1)
                    categories += ", ";
            }
            return "Name: " + name +
                ";\nDisplacement: " + displacement +
                ";\nShipType: " + shipType.ToString() +
                ";\nCabinCategories: " + categories + ".\n";

        }
    }
}
