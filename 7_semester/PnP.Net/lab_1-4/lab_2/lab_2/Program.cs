using lab_2;
using lab_2.Type;
using System.Runtime.InteropServices;

class Program
{
    private static List<Ship> ships = new List<Ship>();
    static void Main(string[] args)
    {
        while (true)
        {
            PrintMenu();
            int choose;
        beforeStart:
            if (int.TryParse(Console.ReadLine(), out int i) && i <= 3)
            {
                choose = i;
            }
            else
            {
                Console.WriteLine("you entered incorrect value or less than.\nTry again");
                goto beforeStart;
            }
            switch (choose)
            {
                case 0:
                    Ship ship = createShip();
                    ships.Add(ship);
                    break;
                case 1:
                    PrintShips();
                    break;
                case 2:
                    Console.WriteLine("Enter index: ");
                beforePrintShip:
                    if (int.TryParse(Console.ReadLine(), out i) && i >= 0)
                    {
                        if (ships.Count == 0)
                        {
                            Console.WriteLine("list is empty");
                            break;
                        }
                        if (i < ships.Count)
                        {
                            PrintShip(i);
                        }
                    }
                    else
                    {
                        Console.WriteLine("you entered incorrect value or less than.\nTry again");
                        goto beforePrintShip;
                    }
                    break;
                case 3:
                beforeInterface:
                    if (int.TryParse(Console.ReadLine(), out i) && i >= 0)
                    {
                        if (ships.Count == 0)
                        {
                            Console.WriteLine("list is empty");
                            break;
                        }
                        if (i < ships.Count)
                        {
                            int degree = int.Parse(Console.ReadLine());
                            ((PassengerShip)ships[i]).TurnLeft(degree);
                            ((PassengerShip)ships[i]).TurnRight(degree);
                        }
                    }
                    else
                    {
                        Console.WriteLine("you entered incorrect value or less than.\nTry again");
                        goto beforeInterface;
                    }
                    break;
                case -1:
                    return;
                default:
                    break;

            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void PrintShip(int index)
    {
        Console.WriteLine(ships[index]);
    }

    private static void PrintMenu()
    {
        Console.WriteLine("0 - add ship");
        Console.WriteLine("1 - print ships");
        Console.WriteLine("2 - print ship by index");
        Console.WriteLine("-1 - exit");
    }

    private static void PrintShips()
    {
        if( ships.Count == 0)
        {
            Console.WriteLine("List is empty");
            return;
        }
        for (int i = 0; i < ships.Count; i++) 
        {
            Console.WriteLine(i + ":\n" + ships[i]);
        }
        //foreach (Ship ship in ships)
        //{
        //    Console.WriteLine(ship);
        //}
    }

    private static Ship createShip()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
    beforeDisplacement:
        Console.WriteLine("Enter displacement: ");
        float displacement = 0;
        if (float.TryParse(Console.ReadLine(), out float f))
        {
            displacement = f;
        }
        else
        {
            Console.WriteLine("you entered incorrect value.\nTry again");
            goto beforeDisplacement;
        }
    beforeShipType:
        Console.WriteLine("choose Ship Type:");
        Console.WriteLine("0 - CargoShip");
        Console.WriteLine("1 - PassengerShip");
        Console.WriteLine("2 - IndustrialShip");
        //int chooseShipType = int.Parse(Console.ReadLine());
        ShipType shipType = 0;
        if (int.TryParse(Console.ReadLine(), out int i) && i <= 2)
        {
            shipType = (ShipType)i;
        }
        else
        {
            Console.WriteLine("you entered incorrect value or less than.\nTry again");
            goto beforeShipType;
        }
        List<CabinCategory> cabinCategories = new List<CabinCategory>();
        Console.WriteLine("Enter cabin categories");
        Console.WriteLine("0 - InsideCabin");
        Console.WriteLine("1 - OutsideCabinWithWindow");
        Console.WriteLine("2 - OutsideCabinWithBalcony");
        Console.WriteLine("3 - Luxury");
        Console.WriteLine("-1 - cancel");
        while (true)
        {
            Console.WriteLine("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out i) && i <= 3)
            {
                if (i == -1)
                    break;
                cabinCategories.Add((CabinCategory)i);
            }
            else
            {
                Console.WriteLine("you entered incorrect value or less than.\nTry again");
                goto beforeShipType;
            }
        }
        Ship ship = new PassengerShip(name, displacement, shipType, cabinCategories);
        return ship;
    }
}


