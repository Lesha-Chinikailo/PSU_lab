using lab_3.exception;
using lab_3.Interface;
using lab_3.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
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
            Console.WriteLine($"Turn Right {degree} degrees");
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
            }
            finally 
            {
                Console.WriteLine("but in principle it is not a mistake");
            }
        }
    }
}
