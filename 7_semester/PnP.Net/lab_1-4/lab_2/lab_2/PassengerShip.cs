using lab_2.exception;
using lab_2.Interface;
using lab_2.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class PassengerShip : Ship, ITurnLeft, ITurnRight
    {
        public PassengerShip()
        {
            
        }
        public PassengerShip(string name, ShipType shipType)
        {
            this.name = name;
            this.shipType = shipType;
        }
        public PassengerShip(string name, float displacement, ShipType shipType, List<CabinCategory> cabinCategories)
        {
            this.name = name;
            this.displacement = displacement;
            this.shipType = shipType;
            this.cabinCategories = new List<CabinCategory>(cabinCategories);
        }
        void ITurnRight.Turn(int degree)
        {
            Console.WriteLine($"Turn Right at corner {degree} degrees");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            TurnLeft(45);
            TurnRight(45);
        }

        void ITurnLeft.Turn(int degree)
        {
            Console.WriteLine($"Turn Left at corner {degree} degrees");
        }

        public void TurnLeft(int degree)
        {
            ((ITurnLeft)this).Turn(degree);
        }

        public void TurnRight(int degree)
        {
            ((ITurnRight)this).Turn(degree);
            try
            {
                if (degree == 0)
                    throw new MyException("why do you need to turn to 0 degrees");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                Console.WriteLine("but in principle it is not a mistake");
            }
            finally 
            {
                Console.WriteLine("method is correct");
            }
        }
    }
}
